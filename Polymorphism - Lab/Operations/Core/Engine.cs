namespace Operations.Core
{
    using Interfaces;
    using Operations.IO.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWrite writer;

        public Engine(IReader reader, IWrite writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            MathOperations mo = new MathOperations();
            writer.WriteLine(mo.Add(2, 3).ToString());
            writer.WriteLine(mo.Add(2.2, 3.3, 5.5).ToString());
            writer.WriteLine(mo.Add(2.2m, 3.3m, 4.4m).ToString());

        }
    }
}
