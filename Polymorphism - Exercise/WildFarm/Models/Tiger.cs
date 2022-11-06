namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed, int foodEaten)
            : base(name, weight, livingRegion, breed, foodEaten)
        {
            this.weightGain = 1.00;
        }

        public override string ProduceSound() => "ROAR!!!";

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
