using System.Collections.Generic;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.Values;

        public void AddItem(IWeapon model)
        {
            if (!this.weapons.ContainsKey(model.GetType().Name))
            {
                this.weapons.Add(model.GetType().Name, model);
            }
        }

        public IWeapon FindByName(string name)
        {
            if (this.weapons.ContainsKey(name))
                return this.weapons[name];
            return null;
        }

        public bool RemoveItem(string name)
        {
            if (this.weapons.ContainsKey(name))
            {
                this.weapons.Remove(name);
                return true;
            }
            return false;
        }
    }
}
