using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private HashSet<IPilot> models;

        public PilotRepository()
        {
            this.models = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IPilot pilot)
        {
            bool inCollection = this.models.Any(p => p.FullName == pilot.FullName);
            if (!inCollection)
            {
                this.models.Add(pilot);
            }
        }

        public bool Remove(IPilot pilot)
        {
            IPilot pilotToRemove = this.models.FirstOrDefault(p => p.FullName == pilot.FullName);
            if (pilotToRemove != null)
            {
                this.models.Remove(pilotToRemove);
                return true;
            }

            return false;
        }

        public IPilot FindByName(string fullName)
        {
            return this.models.FirstOrDefault(p => p.FullName == fullName);
        }
    }
}
