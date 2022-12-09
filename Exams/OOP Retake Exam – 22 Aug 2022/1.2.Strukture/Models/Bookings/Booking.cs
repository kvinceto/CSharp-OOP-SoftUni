using System;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get
            {
                return this.residenceDuration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get
            {
                return this.adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childrenCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber => this.bookingNumber;

        public string BookingSummary()
        {
            double paid = Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
            return $"Booking number: {this.BookingNumber}"
                   + Environment.NewLine
                   + $"Room type: {this.Room.GetType().Name}"
                   + Environment.NewLine
                   + $"Adults: {this.AdultsCount} Children: {this.ChildrenCount}"
                   + Environment.NewLine
                   + $"Total amount paid: {paid:f2}$";
        }
    }
}
