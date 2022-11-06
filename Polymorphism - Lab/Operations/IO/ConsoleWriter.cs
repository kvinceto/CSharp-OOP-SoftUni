namespace Operations.IO
{
    using System;

    using Interfaces;

    public class ConsoleWriter : IWrite
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
