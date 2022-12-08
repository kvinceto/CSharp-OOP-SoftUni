using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            var l = this.weapons.FindByName(name);
            if (l != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");

            string result = String.Empty;
            IWeapon weapon = null;
            switch (type)
            {
                case "Claymore":
                    weapon = new Claymore(name, durability);
                    break;
                case "Mace":
                    weapon = new Mace(name, durability);
                    break;
                default:
                    throw new InvalidOperationException("Invalid weapon type.");
            }

            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            var h = this.heroes.FindByName(name);
            if (h != null)
                throw new InvalidOperationException($"The hero {name} already exists.");

            string result = String.Empty;
            IHero hero = null;
            switch (type)
            {
                case "Barbarian":
                    hero = new Barbarian(name, health, armour);
                    result = $"Successfully added Barbarian {name} to the collection.";
                    break;
                case "Knight":
                    hero = new Knight(name, health, armour);
                    result = $"Successfully added Sir {name} to the collection.";
                    break;
                default:
                    throw new InvalidOperationException("Invalid hero type.");
            }

            this.heroes.Add(hero);
            return result;
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var h = this.heroes.FindByName(heroName);
            if (h == null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");

            var w = this.weapons.FindByName(weaponName);
            if (w == null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            if (h.Weapon != null)
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            h.AddWeapon(w);
            this.weapons.Remove(w);

            return $"Hero {heroName} can participate in battle using a {w.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            IMap map = new Map();
            var fighters = this.heroes.Models
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToList();
            return map.Fight(fighters);
        }

        public string HeroReport()
        {
            List<IHero> iHeroes = this.heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var iHero in iHeroes)
            {
                sb.Append(iHero.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
