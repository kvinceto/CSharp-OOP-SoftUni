namespace BorderControl
{
    public class Robot : Identifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
    }
}
