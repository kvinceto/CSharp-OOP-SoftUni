using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            var buyers = AddBuyers(linesCount);

            BuyFood(buyers);

            PrintResult(buyers);
        }

        private static List<IBuyer> AddBuyers(int linesCount)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputData.Length == 4)
                {
                    Citizen citizen = new Citizen(inputData[0], int.Parse(inputData[1]), inputData[2], inputData[3]);
                    buyers.Add(citizen);
                }
                else if (inputData.Length == 3)
                {
                    Rebel rebel = new Rebel(inputData[0], int.Parse(inputData[1]), inputData[2]);
                    buyers.Add(rebel);
                }
            }

            return buyers;
        }

        private static void BuyFood(List<IBuyer> buyers)
        {
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End") break;
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == name);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
        }

        private static void PrintResult(List<IBuyer> buyers) => 
            Console.WriteLine(buyers.Sum(b => b.Food));
    }
}
