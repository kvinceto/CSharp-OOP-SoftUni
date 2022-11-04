namespace BirthdayCelebrations
{
    public class Robot : Identifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
            Birthday = "0000";
        }

        public string Model { get; set; }
    }
}
