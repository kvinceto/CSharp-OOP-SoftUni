namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed, int foodEaten)
            : base(name, weight, livingRegion, breed, foodEaten)
        {
            this.weightGain = 0.30;
        }

        public override string ProduceSound() => "Meow";

        public override void Feed(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += this.weightGain * food.Quantity;
                return;
            }

            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
