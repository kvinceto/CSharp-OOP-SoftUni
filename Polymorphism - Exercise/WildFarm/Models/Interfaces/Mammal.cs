namespace WildFarm.Models.Interfaces
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion, int foodEaten)
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
