﻿namespace WildFarm.Models.Interfaces
{
    public abstract class Animal
    {
        protected double weightGain;
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public abstract void Feed(Food food);
    }
}