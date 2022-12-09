using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (this.hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            this.hotels.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room = null;
            switch (roomTypeName)
            {
                case "Apartment": room = new Apartment(); break;
                case "DoubleBed": room = new DoubleBed(); break;
                case "Studio": room = new Studio(); break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
                return string.Format(OutputMessages.RoomTypeNotCreated);

            if (room.PricePerNight != 0)
                throw new InvalidOperationException(String.Format(ExceptionMessages.PriceAlreadySet));

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> hotelsByName = this.hotels.All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName)
                .ToList();
            if (hotelsByName.Count == 0)
                return string.Format(OutputMessages.CategoryInvalid, category);

            Dictionary<IRoom, IHotel> rooms = new Dictionary<IRoom, IHotel>();
            foreach (var hotel in hotelsByName)
            {
                foreach (var room in hotel.Rooms.All().Where(r => r.PricePerNight > 0))
                {
                    rooms.Add(room, hotel);
                }
            }

            rooms = rooms.OrderBy(r => r.Key.BedCapacity).ToDictionary(r => r.Key, r => r.Value);

            int bedsNeeded = adults + children;
            IRoom roomToBook = rooms.Keys.FirstOrDefault(r => r.BedCapacity >= bedsNeeded);
            if (roomToBook == null)
                return string.Format(OutputMessages.RoomNotAppropriate);

            IHotel hotelToBook = rooms[roomToBook];
            int bookingNumber = hotelToBook.Bookings.All().Count + 1;
            IBooking booking = new Booking(roomToBook, duration, adults, children, bookingNumber);
            hotelToBook.Bookings.AddNew(booking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotelToBook.FullName);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            string turnover = $"{(Math.Round(hotel.Turnover, 2)):f2}";
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Hotel name: {hotel.FullName}")
                .AppendLine($"--{hotel.Category} star hotel")
                .AppendLine($"--Turnover: {turnover} $")
                .AppendLine($"--Bookings:")
                .AppendLine();
            if (hotel.Bookings.All().Count == 0)
                sb.AppendLine($"none");
            foreach (var booking in hotel.Bookings.All().OrderBy(b=> b.BookingNumber))
            {
                sb.AppendLine(booking.BookingSummary()).AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
