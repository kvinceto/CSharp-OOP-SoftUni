using System;
using System.Collections.Generic;
using System.Linq;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private Workshop workshop;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            switch (bunnyType)
            {
                case "HappyBunny": bunny = new HappyBunny(bunnyName); break;
                case "SleepyBunny": bunny = new SleepyBunny(bunnyName); break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidBunnyType));
            }

            this.bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentBunny));

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
           List<IBunny> workers = this.bunnies.Models
               .Where(b => b.Energy >= 50)
               .OrderByDescending(b => b.Energy)
               .ToList();

           if (workers.Count == 0)
               throw new InvalidOperationException(string.Format(ExceptionMessages.BunniesNotReady));

           IEgg egg = this.eggs.FindByName(eggName);

           foreach (var worker in workers)
           {
                workshop.Color(egg, worker);
                if(egg.IsDone())
                    break;
           }

           List<IBunny> toRemove = this.bunnies.Models
               .Where(b => b.Energy == 0)
               .ToList();
           foreach (var bunny in toRemove)
           {
               this.bunnies.Remove(bunny);
           }
           if(egg.IsDone()) 
               return string.Format(OutputMessages.EggIsDone, eggName);
           else
               return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            List<IEgg> eggsDone = this.eggs.Models.Where(e => e.IsDone()).ToList();

            string result = $"{eggsDone.Count} eggs are done!"
                + Environment.NewLine
                + $"Bunnies info:"
                + Environment.NewLine;
            List<IBunny> b = this.bunnies.Models.ToList();
            foreach (var bunny in b)
            {
                result += bunny.ToString() + Environment.NewLine;
            }

            return result.TrimEnd();
        }
    }
}
