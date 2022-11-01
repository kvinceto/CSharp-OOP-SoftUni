using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }
        private string FlourType
        {
            get => flourType;
            set
            {
                if (value.ToLower() == "white") flourType = "White";
                else if (value.ToLower() == "wholegrain") flourType = "Wholegrain";
                else throw new ArgumentException("Invalid type of dough.");
            }
        }

        private string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() == "crispy") bakingTechnique = "Crispy";
                else if (value.ToLower() == "chewy") bakingTechnique = "Chewy";
                else if (value.ToLower() == "homemade") bakingTechnique = "Homemade";
                else throw new ArgumentException("Invalid type of dough.");
            }
        }

        private double Grams
        {
            get => grams;
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                grams = value;
            }
        }

        public double Calories => GetCalories();

        private double GetCalories()
        {
            return 2 * Grams * GetFlourModifier(FlourType) * GetBakingModifier(BakingTechnique);
        }

        private double GetBakingModifier(string technique)
        {
            double m = 0;
            switch (technique)
            {
                case "Crispy": m = 0.9; break;
                case "Chewy": m = 1.1; break;
                case "Homemade": m = 1.0; break;
            }

            return m;
        }

        private double GetFlourModifier(string flour)
        {
            double m = 0;
            switch (flour)
            {
                case "White": m = 1.5; break;
                case "Wholegrain": m = 1.0; break;
            }
            return m;
        }
    }
}
