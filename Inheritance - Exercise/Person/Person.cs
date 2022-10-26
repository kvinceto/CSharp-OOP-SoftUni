
using System;
using System.Text;

namespace Person
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }

        private int age;
        public int Age
        {
            get => age;
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                this.Name,
                this.Age));

            return stringBuilder.ToString();

        }
    }
}
