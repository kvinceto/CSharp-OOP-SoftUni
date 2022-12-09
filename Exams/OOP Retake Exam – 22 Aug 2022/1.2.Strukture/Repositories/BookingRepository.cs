using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model) => this.bookings.Add(model);

        public IBooking Select(string criteria) => this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == criteria); 

        public IReadOnlyCollection<IBooking> All() => this.bookings;
    }
}
