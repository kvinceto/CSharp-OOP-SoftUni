using System;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                this.name = value;
            }
        }

        public string Size
        {
            get => this.size;
            private set
            {
                this.size = value;
            }
        }

        public double Price
        {
            get => this.price;
            private set
            {
                if (this.Size == "Large")
                {
                    this.price = value;
                }
                else if (this.Size == "Middle")
                {
                    this.price = (value * 2) / 3;
                }
                else if (this.Size == "Small")
                {
                    this.price = (value * 1) / 3;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
