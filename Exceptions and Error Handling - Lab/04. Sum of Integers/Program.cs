using System;

namespace _04._Sum_of_Integers
{
    internal class Program
    {
        private static int numbersSum;
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            foreach (var item in input)
            {
                try
                {
                    ProcessItem(item);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{item}' processed - current sum: {numbersSum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {numbersSum}");
        }

        private static void ProcessItem(string item)
        {
            int n = int.Parse(item);
            numbersSum += n;
        }
    }
}
