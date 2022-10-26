
namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            Name = name;
            Age = age;
        }

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 15)
                {
                    age = value;
                }
            }
        }
    }
}
