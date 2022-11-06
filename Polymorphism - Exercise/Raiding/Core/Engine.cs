using System.Collections.Generic;

namespace Raiding.Core
{
    using System;

    using Interfaces;
    using Models;
    using Raiding.IO.Interfaces;
    using Raiding.Models.Interfaces;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int numberOfHeroesNeeded = int.Parse(reader.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            var powerSum = AddHeroes(numberOfHeroesNeeded, heroes);

            PrintResult(powerSum);
        }

        private int AddHeroes(int numberOfHeroesNeeded, List<BaseHero> heroes)
        {
            int powerSum = 0;

            HeroCreator creator = new HeroCreator();
            while (heroes.Count < numberOfHeroesNeeded)
            {
                try
                {
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();
                    BaseHero hero = creator.CreateHero(type, name);
                    heroes.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                powerSum += hero.Power;
            }
            return powerSum;
        }

        private void PrintResult(int powerSum)
        {
            int powerToReach = int.Parse(reader.ReadLine());

            writer.WriteLine(powerToReach <= powerSum
                ? "Victory!"
                : "Defeat...");
        }
    }
}
