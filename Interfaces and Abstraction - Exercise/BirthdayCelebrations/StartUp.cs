using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Identifiable> identifiableList = new List<Identifiable>();
            string[] separators = { "<", ">", " "};
            AddCitizensRobotsAndPets(separators, identifiableList);

            var listToPrint = Filter(identifiableList);

            PrintBirthdays(listToPrint);
        }

        private static void AddCitizensRobotsAndPets(string[] separators, List<Identifiable> identifiableList)
        {
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End") break;
                switch (input[0])
                {
                    case "Citizen":
                        Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                        identifiableList.Add(citizen);
                        break;
                    case "Robot":
                        Robot robot = new Robot(input[1], input[2]);
                        identifiableList.Add(robot);
                        break;
                    case "Pet":
                        Pet pet = new Pet(input[1], input[2]);
                        identifiableList.Add(pet);
                        break;
                }
            }
        }

        private static List<Identifiable> Filter(List<Identifiable> identifiableList)
        {
            string year = Console.ReadLine();
            List<Identifiable> listToPrint = new List<Identifiable>();
            foreach (var identifiable in identifiableList)
            {
                bool valid = CheckYear(identifiable, year);
                if (valid)
                {
                    listToPrint.Add(identifiable);
                }
            }

            return listToPrint;
        }

        private static void PrintBirthdays(List<Identifiable> listToPrint)
        {
            foreach (var identifiable in listToPrint)
            {
                Console.WriteLine(identifiable.Birthday);
            }
        }

        private static bool CheckYear(Identifiable identifiable, string year)
        {
            string substring = identifiable.Birthday.Substring(identifiable.Birthday.Length - year.Length);
            if(substring == year)
                return true;
            return false;
        }
    }
}
