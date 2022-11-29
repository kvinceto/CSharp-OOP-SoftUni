using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;


        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            bool repositoryContainsPilot = this.pilotRepository.Models.Any(p => p.FullName == fullName);
            if (repositoryContainsPilot)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            bool repositoryContainsCar = this.carRepository.Models.Any(c => c.Model == model);
            if (repositoryContainsCar)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car = null;
            switch (type)
            {
                case "Ferrari":
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    break;
                case "Williams":
                    car = new Williams(model, horsepower, engineDisplacement);
                    break;
            }

            this.carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = this.carRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);
            bool canRace = pilot.CanRace;
            bool inTheRace = race.Pilots.Contains(pilot);
            if (pilot == null )
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, raceName));
            }
            if (canRace == false || inTheRace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }

            int numberOfPilots = race.Pilots.Count;
            if (numberOfPilots < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage,raceName));
            }

            Dictionary<IPilot, double> raceResults = new Dictionary<IPilot, double>();
            foreach (var pilot in race.Pilots)
            {
                double result = pilot.Car.RaceScoreCalculator(race.NumberOfLaps);
                raceResults.Add(pilot, result);
            }

            race.TookPlace = true;
            var winers = raceResults
                .OrderByDescending(p => p.Value)
                .Take(3)
                .ToDictionary(p => p.Key, p => p.Value);
            StringBuilder output = new StringBuilder();
            int counter = 0;
            foreach (var kvp in winers)
            {
                counter++;
                switch (counter)
                {
                    case 1:
                        kvp.Key.WinRace();
                        output.AppendLine($"Pilot {kvp.Key.FullName} wins the {raceName} race.");
                        break;
                    case 2:
                        kvp.Key.WinRace();
                        output.AppendLine($"Pilot {kvp.Key.FullName} is second in the {raceName} race.");
                        break;
                    case 3:
                        kvp.Key.WinRace();
                        output.Append($"Pilot {kvp.Key.FullName} is third in the {raceName} race.");
                        break;
                }
            }

            return output.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder output = new StringBuilder();
            var races = this.raceRepository.Models.Where(r => r.TookPlace == true);
            foreach (var race in races)
            {
                output.AppendLine(race.RaceInfo());
            }

            return output.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder output = new StringBuilder();
            var pilots = this.pilotRepository.Models
                .OrderByDescending(p => p.NumberOfWins).ToList();
            foreach (var pilot in pilots)
            {
                output.AppendLine(pilot.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
