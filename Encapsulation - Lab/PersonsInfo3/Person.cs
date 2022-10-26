
using System;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }

        private int age;

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;

            }

        }

        private decimal salary;

        public decimal Salary
        {
            get => salary;
            set
            {
                if (value < 650M)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                salary = value;
            }
        }


        public void IncreaseSalary(decimal percentage)
        {
            Salary += Age < 30
                ? Salary * (percentage / 100 / 2)
                : Salary * percentage / 100;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
