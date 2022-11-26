namespace CommandPattern.Core.Commands
{
    using System;

    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] input)
        {
            Environment.Exit(0);
            return null;
        }
    }
}