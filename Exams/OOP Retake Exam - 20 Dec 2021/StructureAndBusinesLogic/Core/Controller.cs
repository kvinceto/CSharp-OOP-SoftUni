using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vesselsRepository;
        private Dictionary<string, ICaptain> captainsByName;

        public Controller()
        {
            this.vesselsRepository = new VesselRepository();
            this.captainsByName = new Dictionary<string, ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);
            if (this.captainsByName.ContainsKey(fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            this.captainsByName.Add(fullName, captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vesselsRepository.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            Vessel vessel = null;
            switch (vesselType)
            {
                case "Battleship": vessel = new Battleship(name, mainWeaponCaliber, speed); break;
                case "Submarine": vessel = new Submarine(name, mainWeaponCaliber, speed); break;
                default:
                    return string.Format(OutputMessages.InvalidVesselType);
            }

            this.vesselsRepository.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!this.captainsByName.ContainsKey(selectedCaptainName))
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            ICaptain captain = this.captainsByName[selectedCaptainName];

            IVessel vessel = this.vesselsRepository.FindByName(selectedVesselName);
            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if (vessel.Captain != null)
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            vessel.Captain = captain;
            captain.Vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
            => this.captainsByName[captainFullName].Report();

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vesselsRepository.FindByName(vesselName);
            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vesselsRepository.FindByName(vesselName);
            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            if (vessel is Battleship battleship)
            {
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            if (vessel is Submarine submarine)
            {
                submarine.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }

            return null;
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = this.vesselsRepository.FindByName(attackingVesselName);
            if (attacker == null)
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            IVessel defender = this.vesselsRepository.FindByName(defendingVesselName);
            if (defender == null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attacker.ArmorThickness <= 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (defender.ArmorThickness <= 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vesselsRepository.FindByName(vesselName);
            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
    }
}
