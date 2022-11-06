namespace WildFarm.Models.Interfaces
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize, int foodEaten) 
            : base(name, weight, foodEaten)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ProduceSound() => "";

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
