using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {

        private HashSet<IRace> models;

        public RaceRepository()
        {
            this.models = new HashSet<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(IRace race)
        {
            bool inCollection = this.models.Any(r => r.RaceName == race.RaceName);
            if (!inCollection)
            {
                this.models.Add(race);
            }
        }

        public bool Remove(IRace race)
        {
            IRace raceToRemove = this.models.FirstOrDefault(r => r.RaceName == race.RaceName);
            if (raceToRemove != null)
            {
                this.models.Remove(raceToRemove);
                return true;
            }

            return false;
        }

        public IRace FindByName(string raceName)
        {
            return this.models.FirstOrDefault(r => r.RaceName == raceName);
        }
    }
}
