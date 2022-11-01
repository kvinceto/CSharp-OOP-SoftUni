using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MAX_NUMBER_OF_TOPPINGS = 10;
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
            Dough = null;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public int NumberOfToppings => toppings.Count;
        public double TotalCalories => GetTotalCalories();

        private double GetTotalCalories()
        {
            double calories = 0;
            calories += this.Dough.Calories;
            foreach (var topping in toppings)
            {
                calories += topping.Calories;
            }
            return calories;
        }

        public Dough Dough
        {
            private get => dough;
            set { dough = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings >= MAX_NUMBER_OF_TOPPINGS)
            {
                throw new AggregateException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }

}
