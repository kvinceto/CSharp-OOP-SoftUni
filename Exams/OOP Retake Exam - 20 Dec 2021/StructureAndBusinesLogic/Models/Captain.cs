using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));
                }

                this.fullName = value;
            }
        }

        public int CombatExperience
        {
            get
            {
                return this.combatExperience;
            }
        }

        public ICollection<IVessel> Vessels
        {
            get
            {
                return this.vessels;
            }
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();
           sb.AppendLine(
               $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.vessels.Count} vessels.");
           if (vessels.Count > 0)
           {
               foreach (var vessel in this.vessels)
               {
                   sb.AppendLine(vessel.ToString());
               }
           }

           return sb.ToString().Trim();
        }

        public bool Equals(object otherObj)
        {
            Captain other = otherObj as Captain;
            return fullName == other.fullName && combatExperience == other.combatExperience && Equals(vessels, other.vessels);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(fullName, combatExperience, vessels);
        }
    }
}
