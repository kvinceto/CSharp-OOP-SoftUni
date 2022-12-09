using System.Collections.Generic;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private Dictionary<string, IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new Dictionary<string, IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.units.Values;

        public void AddItem(IMilitaryUnit model)
        {
            if (!this.units.ContainsKey(model.GetType().Name))
            {
                this.units.Add(model.GetType().Name, model);
            }
        }

        public IMilitaryUnit FindByName(string name)
        {
            if (this.units.ContainsKey(name))
            {
                return this.units[name];
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (this.units.ContainsKey(name))
            {
                this.units.Remove(name);
                return true;
            }
            return false;
        }
    }
}
