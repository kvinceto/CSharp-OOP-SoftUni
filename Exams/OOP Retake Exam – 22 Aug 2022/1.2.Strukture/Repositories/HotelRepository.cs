using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model) => this.hotels.Add(model);

        public IHotel Select(string criteria) => this.hotels.FirstOrDefault(h => h.FullName == criteria);

        public IReadOnlyCollection<IHotel> All() => this.hotels;
    }
}
