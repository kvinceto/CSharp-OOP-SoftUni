using System.Collections.Generic;
using System.Linq;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> list;

        public EquipmentRepository()
        {
            this.list = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => this.list;

        public void Add(IEquipment model) => this.list.Add(model);

        public bool Remove(IEquipment model) => this.list.Remove(model);

        public IEquipment FindByType(string type)
            => this.list.FirstOrDefault(e => e.GetType().Name == type);
    }
}
