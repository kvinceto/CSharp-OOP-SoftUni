namespace Animals.Core
{
    using Animals.IO.Interfaces;
    using Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            writer.WriteLine(cat.ExplainSelf());
            writer.WriteLine(dog.ExplainSelf());

        }
    }
}
