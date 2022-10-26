using System;
using System.Linq;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public virtual string Gender { get { return gender; } set { gender = value; } }

        public Animal(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public Animal()
        { }

        public virtual string ProduceSound()
            => null;

        public override string ToString()
            => this.GetType().ToString().Split('.').Last() + Environment.NewLine +
               $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
               ProduceSound();
    }

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        { }

        public override string ProduceSound()
            => "Meow meow";
    }
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        { }

        public override string ProduceSound()
            => "Woof!";
    }
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        { }

        public override string ProduceSound()
            => "Ribbit";
    }
    public class Kitten : Cat
    {
        private const string FIXED_GENDER = "Female";

        public override string Gender { get { return FIXED_GENDER; } }

        public Kitten(string name, int age)
            : base(name, age, null)
        { }

        public override string ProduceSound()
            => "Meow";
    }
    public class Tomcat : Cat
    {
        private const string FIXED_GENDER = "Male";

        public override string Gender { get { return FIXED_GENDER; } }

        public Tomcat(string name, int age)
            : base(name, age, null)
        { }

        public override string ProduceSound()
            => "MEOW";
    }
}
