using System.Collections.Generic;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private Dictionary<string, IWeapon> weaponsByName;

        public WeaponRepository()
        {
            this.weaponsByName = new Dictionary<string, IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weaponsByName.Values;

        public void Add(IWeapon model)
        {
            if (!this.weaponsByName.ContainsKey(model.Name))
                this.weaponsByName.Add(model.Name, model);
        }

        public bool Remove(IWeapon model)
        {
            if (this.weaponsByName.ContainsKey(model.Name))
            {
                this.weaponsByName.Remove(model.Name);
                return true;
            }

            return false;
        }

        public IWeapon FindByName(string name)
        {
            if (this.weaponsByName.ContainsKey(name))
                return this.weaponsByName[name];

            return null;
        }
    }
}
