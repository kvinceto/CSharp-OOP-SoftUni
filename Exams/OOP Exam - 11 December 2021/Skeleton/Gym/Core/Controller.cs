using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            switch (gymType)
            {
                case "BoxingGym": gym = new BoxingGym(gymName); break;
                case "WeightliftingGym": gym = new WeightliftingGym(gymName); break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }

            this.gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;
            switch (equipmentType)
            {
                case "BoxingGloves": equipment = new BoxingGloves(); break;
                case "Kettlebell": equipment = new Kettlebell(); break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEquipmentType));
            }

            this.equipment.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if (equipment == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,
                    equipmentType));

            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            if (gym == null)
                throw new InvalidOperationException();

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            switch (athleteType)
            {
                case "Boxer": athlete = new Boxer(athleteName, motivation, numberOfMedals); break;
                case "Weightlifter": athlete = new Weightlifter(athleteName, motivation, numberOfMedals); break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAthleteType));
            }

            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            bool isCorrect = false;
            if (athlete is Boxer)
            {
                isCorrect = gym is BoxingGym;
            }
            else if (athlete is Weightlifter)
            {
                isCorrect = gym is WeightliftingGym;
            }

            if (!isCorrect)
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            double n = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, n);
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();

           foreach (var gym in this.gyms)
           {
               sb.AppendLine(gym.GymInfo());
           }

           return sb.ToString().Trim();
        }
    }
}
