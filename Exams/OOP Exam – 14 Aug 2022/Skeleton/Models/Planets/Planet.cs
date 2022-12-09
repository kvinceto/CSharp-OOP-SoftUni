using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        private double militaryPower;

        public Planet(string name, double budget)
        {
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => this.MilitaryPowerCalculator();

        private double MilitaryPowerCalculator()
        {
            double result = this.units.Models.Sum(u => u.EnduranceLevel) +
                            this.weapons.Models.Sum(w => w.DestructionLevel);
            if (this.units.Models.Any(u => u is AnonymousImpactUnit))
            {
                result += result * 0.3;
            }

            if (this.weapons.Models.Any(w => w is NuclearWeapon))
            {
                result += result * 0.45;
            }

            return Math.Round(result, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in this.units.Models.ToList())
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            List<string> u = new List<string>();
            foreach (var unit in this.units.Models)
            {
                u.Add(unit.GetType().Name);
            }

            string unitsInfo = u.Count == 0
                ? "No units"
                : string.Join(", ", u);

            List<string> w = new List<string>();
            foreach (var weapon in this.weapons.Models)
            {
                w.Add(weapon.GetType().Name);
            }

            string weaponsInfo = w.Count == 0
                ? "No weapons"
                : string.Join(", ", w);

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {unitsInfo}")
                .AppendLine($"--Combat equipment: {weaponsInfo}")
                .Append($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }
    }
}
