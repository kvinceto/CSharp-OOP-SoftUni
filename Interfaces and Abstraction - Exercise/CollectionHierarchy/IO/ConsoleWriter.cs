﻿namespace CollectionHierarchy.IO
{
    using System;

    using Interfaces;

    internal class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
