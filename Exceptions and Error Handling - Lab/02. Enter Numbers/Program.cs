using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }

    public class Engine
    {
        private const int NUMBERS_NEEDED = 10;

        public Engine()
        {
            this.Numbers = new List<int>();
        }

        public List<int> Numbers { get; private set; }

        public void Run()
        {
            ReadNumber(1, 100);
            PrintNumbers();
        }

        private void PrintNumbers()
        {
            Console.WriteLine(string.Join(", ", Numbers));
        }

        private void ReadNumber(int start, int end)
        {
            while (this.Numbers.Count < NUMBERS_NEEDED)
            {
                string input = Console.ReadLine();
                try
                {
                    int n = TryParse(input);
                    int lastNumber = Numbers.Count > 0 ? Numbers[Numbers.Count - 1] : start;
                    if (lastNumber < n && n < end)
                    {
                        Numbers.Add(n);
                    }
                    else
                    {
                        throw new ArgumentException($"Your number is not in range {lastNumber} - 100!");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private int TryParse(string input)
        {
            bool isNumber = true;

            foreach (var t in input)
            {
                if (!Char.IsDigit(t))
                {
                    isNumber = false;
                    break;
                }
            }

            if (!isNumber)
                throw new ArgumentException("Invalid Number!");

            return int.Parse(input);
        }
    }
}
