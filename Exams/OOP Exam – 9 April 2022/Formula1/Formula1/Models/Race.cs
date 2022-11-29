﻿using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.TookPlace = false;
            pilots = new HashSet<IPilot>();
        }

        public string RaceName
        {
            get
            {
                return this.raceName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return this.pilots;
            }
        }

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookPlace = this.TookPlace == true
                ? "Yes"
                : "No";
           StringBuilder sb = new StringBuilder();
           sb
               .AppendLine($"The {this.RaceName} race has:")
               .AppendLine($"Participants: {this.pilots.Count}")
               .AppendLine($"Number of laps: {this.NumberOfLaps}")
               .Append($"Took place: {tookPlace}");

           return sb.ToString();
        }
    }
}
