using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int exeptionsCatched = 0;

            while (exeptionsCatched < 3)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                try
                {
                    switch (cmd[0])
                    {
                        case "Replace":
                            ReplaceCommand(cmd, numbers);
                            break;
                        case "Print":
                            PrintCommand(cmd, numbers);
                            break;
                        case "Show":
                            ShowCommand(cmd, numbers);
                            break;
                    }
                }
                catch (IndexOutOfRangeException iofre)
                {
                    Console.WriteLine("The index does not exist!");
                    exeptionsCatched++;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exeptionsCatched++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ReplaceCommand(string[] cmd, int[] numbers)
        {
            int index = int.Parse(cmd[1]);
            if (index < 0 || index >= numbers.Length)
                throw new IndexOutOfRangeException();
            int element = int.Parse(cmd[2]);
            numbers[index] = element;
        }

        private static void PrintCommand(string[] cmd, int[] numbers)
        {
            int startIndex = int.Parse(cmd[1]);
            int endIndex = int.Parse(cmd[2]);
            if (startIndex > endIndex || startIndex < 0 || startIndex >= numbers.Length ||
                endIndex < 0 || endIndex >= numbers.Length)
                throw new IndexOutOfRangeException();
            List<int> n = new List<int>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                n.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(", ", n));
        }

        private static void ShowCommand(string[] cmd, int[] numbers)
        {
            int index = int.Parse(cmd[1]);
            if (index < 0 || index >= numbers.Length)
                throw new IndexOutOfRangeException();
            Console.WriteLine(numbers[index]);
        }
    }
}
