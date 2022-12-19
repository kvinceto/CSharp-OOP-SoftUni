using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private Dictionary<int, IUniversity> universities;

        public UniversityRepository()
        {
            this.universities = new Dictionary<int, IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => this.universities.Values;

        public void AddModel(IUniversity model)
        {
            this.universities[model.Id] = model;
        }

        public IUniversity FindById(int id)
        {
            return this.universities[id];
        }

        public IUniversity FindByName(string name)
        {
           return this.universities.Values.FirstOrDefault(u => u.Name == name);
        }
    }
}
