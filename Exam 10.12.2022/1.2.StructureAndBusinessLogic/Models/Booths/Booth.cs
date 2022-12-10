using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            this.boothId = boothId;
            this.Capacity = capacity;
            this.currentBill = 0;
            this.turnover = 0;
            this.isReserved = false;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
        }

        public int BoothId => this.boothId;

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }
                this.capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;

        public double CurrentBill => this.currentBill;

        public double Turnover => this.turnover;

        public bool IsReserved => this.isReserved;

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill += amount;
        }

        public void Charge()
        {
            this.turnover += this.currentBill;
            this.currentBill = 0;
        }

        public void ChangeStatus()
        {
            if (this.isReserved)
            {
                isReserved = false;
            }
            else
            {
                isReserved = true;
            }
        }

        public override string ToString()
        {
            string turnoverToString = $"{this.Turnover:f2}";
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Booth: {this.BoothId}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Turnover: {turnoverToString} lv")
                .AppendLine($"-Cocktail menu:");

            foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }

            sb.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
