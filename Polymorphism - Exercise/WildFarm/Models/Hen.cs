namespace WildFarm.Models
{
    using Interfaces;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize, int foodEaten)
            : base(name, weight, wingSize, foodEaten)
        {
            this.weightGain = 0.35;
        }

        public override string ProduceSound() => "Cluck";

        public override void Feed(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += this.weightGain * food.Quantity;
        }
    }
}
