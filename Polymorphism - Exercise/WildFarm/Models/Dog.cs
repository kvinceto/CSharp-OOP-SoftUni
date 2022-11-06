namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion, int foodEaten)
            : base(name, weight, livingRegion, foodEaten)
        {
            this.weightGain = 0.40;
        }

        public override string ProduceSound() => "Woof!";

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
