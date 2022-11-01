using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }
        private string Type
        {
            get => type;
            set
            {
                if (value.ToLower() == "meat") type = "Meat";
                else if (value.ToLower() == "veggies") type = "Veggies";
                else if (value.ToLower() == "cheese") type = "Cheese";
                else if (value.ToLower() == "sauce") type = "Sauce";
                else
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }

        private double Grams
        {
            get => grams;
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                grams = value;
            }
        }

        public double Calories => GetCalories();

        private double GetCalories()
        {
            return 2 * Grams * GetModifier(Type);
        }

        private double GetModifier(string typeOfTopping)
        {
            double m = 0;
            switch (typeOfTopping)
            {
                case "Meat": m = 1.2; break;
                case "Veggies": m = 0.8; break;
                case "Cheese": m = 1.1; break;
                case "Sauce": m = 0.9; break;
            }
            return m;
        }
    }
}
