namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, wingSize, foodEaten)
        {
            this.weightGain = 0.25;
        }

        public override string ProduceSound() => "Hoot Hoot";

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.weightGain * food.Quantity;
                return;
            }

            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
