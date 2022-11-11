using System;

namespace _01._Square_Root
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                    throw new ArgumentException("Invalid number.");
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);   
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }


        }
    }
}
