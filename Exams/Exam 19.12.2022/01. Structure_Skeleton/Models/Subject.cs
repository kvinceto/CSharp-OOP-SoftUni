using System;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;

        protected Subject(int subjectId, string subjectName, double subjectRate)
        {
            this.Id = subjectId;
            this.Name = subjectName;
            this.Rate = subjectRate;
        }
        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                this.name = value;
            }
        }

        public double Rate
        {
            get { return this.rate; }
            private set { this.rate = value; }
        }
    }
}
