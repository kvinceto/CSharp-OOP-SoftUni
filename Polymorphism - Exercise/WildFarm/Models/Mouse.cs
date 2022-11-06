namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion, int foodEaten)
            : base(name, weight, livingRegion, foodEaten)
        {
            this.weightGain = 0.1;
        }

        public override string ProduceSound() => "Squeak";

        public override void Feed(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.weightGain * food.Quantity;
                return;
            }

            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
