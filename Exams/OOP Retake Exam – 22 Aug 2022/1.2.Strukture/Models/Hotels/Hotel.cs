using System;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.bookings = new BookingRepository();
            this.rooms = new RoomRepository();
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.HotelNameNullOrEmpty));
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCategory));
                }
                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double result = 0;
                foreach (var booking in this.Bookings.All())
                {
                    result += booking.ResidenceDuration * booking.Room.PricePerNight;
                }

                return Math.Round(result, 2);
            }
        }
        public IRepository<IRoom> Rooms => this.rooms;

        public IRepository<IBooking> Bookings => this.bookings;
    }
}
