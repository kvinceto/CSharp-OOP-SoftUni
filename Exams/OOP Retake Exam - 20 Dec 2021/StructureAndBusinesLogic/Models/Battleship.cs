using System;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.defaultArmor = 300;
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
        }

        public override string ToString()
        {
            return base.ToString() 
                   + Environment.NewLine 
                   + $"*Sonar mode: {(this.SonarMode ? "ON" : "OFF")}";
        }
    }
}
