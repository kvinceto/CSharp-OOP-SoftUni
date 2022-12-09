using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            var planet = this.planets.FindByName(name);
            if (planet != null)
                return string.Format(OutputMessages.ExistingPlanet, name);
            this.planets.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = PlanetFinder(planetName);
            if (unitTypeName == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidUnitName);
            }

            if ((unitTypeName != "AnonymousImpactUnit" &&
                 unitTypeName != "SpaceForces" &&
                 unitTypeName != "StormTroopers"))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = null;
            switch (unitTypeName)
            {
                case "AnonymousImpactUnit": unit = new AnonymousImpactUnit(); break;
                case "SpaceForces": unit = new SpaceForces(); break;
                case "StormTroopers": unit = new StormTroopers(); break;
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        private IPlanet PlanetFinder(string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            return planet;
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.PlanetFinder(planetName);
            if (weaponTypeName == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidWeaponName);
            }

            if (weaponTypeName != "BioChemicalWeapon" &&
                weaponTypeName != "NuclearWeapon" &&
                weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            IWeapon weapon = null;
            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon": weapon = new NuclearWeapon(destructionLevel); break;
                case "SpaceMissiles": weapon = new SpaceMissiles(destructionLevel); break;
            }

            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var planet = this.PlanetFinder(planetName);
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }
            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = this.PlanetFinder(planetOne);
            var planet2 = this.PlanetFinder(planetTwo);
            bool pl1Win = false;
            bool pl2Win = false;
            bool planet1IsNuc = false;
            bool planet2IsNuc = false;

            planet1.Spend(planet1.Budget / 2);
            planet2.Spend(planet2.Budget / 2);

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(w => w is NuclearWeapon))
                {
                    planet1IsNuc = true;
                }
                if (planet2.Weapons.Any(w => w is NuclearWeapon))
                {
                    planet2IsNuc = true;
                }

                if ((planet1IsNuc && planet2IsNuc) || (!planet1IsNuc && !planet2IsNuc))
                {
                    return string.Format(OutputMessages.NoWinner);
                }
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                pl1Win = true;
            }
            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                pl2Win = true;
            }

            if (planet1IsNuc)
            {
                pl1Win = true;
            }
            else if (planet2IsNuc)
            {
                pl2Win = true;
            }

            if (pl1Win)
            {
                planet1.Profit(planet2.Budget / 2);
                double win = planet2.Army.ToList().Sum(u => u.Cost) +
                             planet2.Weapons.ToList().Sum(w => w.Price);
                planet1.Profit(win);
                this.planets.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }

            if (pl2Win)
            {
                planet2.Profit(planet1.Budget / 2);
                double win = planet1.Army.ToList().Sum(u => u.Cost) +
                             planet1.Weapons.ToList().Sum(w => w.Price);
                planet2.Profit(win);
                this.planets.RemoveItem(planetOne);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            return "";
        }

        public string ForcesReport()
        {
            List<IPlanet> items = this.planets.Models.ToList().OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in items)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
