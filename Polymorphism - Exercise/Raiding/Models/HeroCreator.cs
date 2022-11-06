namespace Raiding.Models
{
    using System;

    using Interfaces;

    public class HeroCreator : Creator
    {
        public override BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;
            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default: throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }
    }
}
