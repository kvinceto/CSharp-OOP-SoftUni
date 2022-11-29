using System;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace;
        private IFormulaOneCar pilotCar;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.canRace = false;
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return this.pilotCar;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot));
                }

                this.pilotCar = value;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return this.numberOfWins;
            }
        }

        public bool CanRace
        {
            get
            {
                return this.canRace;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
