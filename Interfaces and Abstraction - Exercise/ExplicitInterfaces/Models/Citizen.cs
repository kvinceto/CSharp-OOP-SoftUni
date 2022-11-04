namespace ExplicitInterfaces.Models
{
    using Interfaces;

    public class Citizen : IResident, IPerson
    {
        private string name;
        private string country;
        private int age;

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Age { get; private set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }
    }
}
