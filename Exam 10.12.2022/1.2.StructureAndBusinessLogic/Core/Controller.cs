using System;
using System.Collections.Generic;
using System.Linq;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        private int GetBoothId()
        {
            return this.booths.Models.Count + 1;
        }

        public string AddBooth(int capacity)
        {
            int id = GetBoothId();
            IBooth booth = new Booth(id, capacity);
            this.booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;
            switch (delicacyTypeName)
            {
                case "Gingerbread": delicacy = new Gingerbread(delicacyName); break;
                case "Stolen": delicacy = new Stolen(delicacyName); break;
                default:
                    return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;
            switch (cocktailTypeName)
            {
                case "Hibernation": cocktail = new Hibernation(cocktailName, size); break;
                case "MulledWine": cocktail = new MulledWine(cocktailName, size); break;
                default:
                    return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
                return string.Format(OutputMessages.InvalidCocktailSize, size);

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> availableBooths = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();
            if (availableBooths.Count == 0)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            IBooth booth = availableBooths[0];
            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderArgs = order.Split("/");
            string itemTypeName = orderArgs[0];

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine" &&
                itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            string itemName = orderArgs[1];
            int countOrdered = int.Parse(orderArgs[2]);
            string size = null;
            if (orderArgs.Length == 4)
            {
                size = orderArgs[3];
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            bool isPreasant = false;

            if (size == null)
            {
                if (booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                {
                    isPreasant = true;
                }
            }
            else
            {
                if (booth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    isPreasant = true;
                }
            }

            if (!isPreasant)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            ICocktail cocktailOrder = null;
            IDelicacy delicacyOrder = null;
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                cocktailOrder = booth.CocktailMenu.Models.FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == size);
                if (cocktailOrder == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                double sum = cocktailOrder.Price * countOrdered;
                booth.UpdateCurrentBill(sum);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrdered, itemName);
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                delicacyOrder = booth.DelicacyMenu.Models.FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

                if (delicacyOrder == null)
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                double sum = delicacyOrder.Price * countOrdered;
                booth.UpdateCurrentBill(sum);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrdered, itemName);
            }

            return null;
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            return ($"Bill {bill:f2} lv"
                    + Environment.NewLine
                    + $"Booth {boothId} is now available!"
                    + Environment.NewLine).Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString().Trim();
        }
    }
}
