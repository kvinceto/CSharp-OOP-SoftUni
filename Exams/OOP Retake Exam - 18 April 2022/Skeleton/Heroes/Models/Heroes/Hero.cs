﻿using System;
using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (this.Armour > points)
            {
                this.Armour -= points;
                points = 0;
            }
            else
            {
                points -= this.Armour;
                this.Armour = 0;
            }

            if (points == 0) return;

            if (this.Health > points)
            {
                this.Health -= points;
                points = 0;
            }
            else
            {
                this.Health = 0;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public override string ToString()
        {
            string weaponInfo = this.Weapon == null
                ? "Unarmed"
                : this.Weapon.Name;
            return $"{this.GetType().Name}: {this.Name}"
                   + Environment.NewLine
                   + $"--Health: {this.Health}"
                   + Environment.NewLine
                   + $"--Armour: {this.Armour}"
                   + Environment.NewLine
                   + $"--Weapon: {weaponInfo}"
                   + Environment.NewLine;
        }
    }
}