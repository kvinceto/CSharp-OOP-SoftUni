using System.Collections.Generic;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private Dictionary<string, IVessel> vesselsByName;

        public VesselRepository()
        {
            this.vesselsByName = new Dictionary<string,IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this.vesselsByName.Values;

        public void Add(IVessel model) => this.vesselsByName.Add(model.Name, model);

        public bool Remove(IVessel model)
        {
            if (this.vesselsByName.ContainsKey(model.Name))
            {
                this.vesselsByName.Remove(model.Name);
                return true;
            }
            return false;
        }

        public IVessel FindByName(string name)
        {
            if (this.vesselsByName.ContainsKey(name))
            {
                return this.vesselsByName[name];
            }
            return null;
        }
    }
}
