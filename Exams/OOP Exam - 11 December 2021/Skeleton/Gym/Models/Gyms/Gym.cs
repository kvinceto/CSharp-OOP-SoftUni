using System;
using System.Collections.Generic;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        List<IEquipment> equipment;
        List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight
        {
            get
            {
                double result = 0;
                foreach (var item in this.equipment)
                {
                    result += item.Weight;
                }
                return result;
            }
        }

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == this.athletes.Count)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughSize));
            }

            this.athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            string noAtletes = "No athletes";
            string atlInfo = string.Join(", ", athletes
                .Select(a => a.FullName).ToList());
            string atl = athletes.Count == 0 ? noAtletes : atlInfo;
            string gymType = this.GetType().Name;
            string eqWeight = $"{Math.Round(this.EquipmentWeight, 2):f2}";
            return $"{this.Name} is a {gymType}"
                   + Environment.NewLine
                   + $"Athletes: {atl}"
                   + Environment.NewLine
                   + $"Equipment total count: {this.equipment.Count}"
                   + Environment.NewLine
                   + $"Equipment total weight: {eqWeight} grams";
        }
    }
}
