using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Identifiable> identifiables = new List<Identifiable>();

            AddCitizensAndRobots(identifiables);

            string idData = Console.ReadLine();

            var idToPrint = FilterIds(identifiables, idData);

            PrintIds(idToPrint);

        }

        private static void PrintIds(List<Identifiable> idToPrint)
        {
            foreach (var identifiable in idToPrint)
            {
                Console.WriteLine(identifiable.Id);
            }
        }

        private static List<Identifiable> FilterIds(List<Identifiable> identifiables, string idData)
        {
            List<Identifiable> idToPrint = new List<Identifiable>();
            foreach (Identifiable identifiable in identifiables)
            {
                bool valid = CheckId(identifiable, idData);
                if (valid)
                {
                    idToPrint.Add(identifiable);
                }
            }

            return idToPrint;
        }

        private static void AddCitizensAndRobots(List<Identifiable> identifiables)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End") break;
                if (input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    identifiables.Add(citizen);
                }
                else if (input.Length == 2)
                {
                    Robot robot = new Robot(input[0], input[1]);
                    identifiables.Add(robot);
                }
            }
        }

        private static bool CheckId(Identifiable identifiable, string idData)
        {
            if (identifiable.Id.Length >= idData.Length)
            {
                string substring = identifiable.Id
                    .Substring(identifiable.Id.Length - idData.Length);
                if (substring == idData)
                    return true;
                return false;

            }
            else
            {
                return false;
            }
        }
    }
}
