using System.Collections.Generic;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model) => this.rooms.Add(model);

        public IRoom Select(string criteria) => this.rooms.Find(r => r.GetType().Name == criteria);

        public IReadOnlyCollection<IRoom> All() => this.rooms;
    }
}
