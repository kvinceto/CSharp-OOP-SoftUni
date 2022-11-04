namespace BirthdayCelebrations
{
    public class Pet : Identifiable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
    }
}
