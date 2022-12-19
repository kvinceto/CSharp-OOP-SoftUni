using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private Dictionary<int, IStudent> students;

        public StudentRepository()
        {
            this.students = new Dictionary<int, IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => this.students.Values;

        public void AddModel(IStudent model)
        {
            this.students[model.Id] = model;
        }

        public IStudent FindById(int id)
        {
            return this.students[id];
        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(' ');
            return this.students.Values.FirstOrDefault(s => s.FirstName == fullName[0] && s.LastName == fullName[1]);
        }
    }
}
