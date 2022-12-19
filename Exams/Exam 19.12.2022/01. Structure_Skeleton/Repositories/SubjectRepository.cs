using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        Dictionary<int, ISubject> _subjects;

        public SubjectRepository()
        {
            this._subjects = new Dictionary<int, ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => this._subjects.Values;

        public void AddModel(ISubject model)
        {
            this._subjects[model.Id] = model;
        }

        public ISubject FindById(int id)
        {
            return this._subjects[id];
        }

        public ISubject FindByName(string name)
        {
            return this._subjects.Values.FirstOrDefault(s => s.Name == name);
        }
    }
}
