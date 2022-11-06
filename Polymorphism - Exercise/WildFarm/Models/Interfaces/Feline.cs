namespace WildFarm.Models.Interfaces
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed, int foodEaten)
            : base(name, weight, livingRegion, foodEaten)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override string ProduceSound() => "";

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
