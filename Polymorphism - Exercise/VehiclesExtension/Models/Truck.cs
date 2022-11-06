namespace VehiclesExtension.Models
{
    using System;

    using Interfaces;

    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.fuelConsumptionOfConditioners = 1.6;
            this.fuelQuantity = this.FuelCheck(fuelQuantity);
        }

        protected override double FuelCheck(double fuelToAdd)
        {

            if (fuelToAdd > this.tankCapacity)
            {
                return 0;
            }

            return fuelToAdd;
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = (this.fuelConsumptionPerKm + this.fuelConsumptionOfConditioners) * distance;

            if (fuelNeeded <= this.fuelQuantity)
            {
                this.fuelQuantity -= fuelNeeded;
                return $"Truck travelled {distance} km";
            }

            return $"Truck needs refueling";
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.fuelQuantity + (0.95 * liters) > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.fuelQuantity += 0.95 * liters;
        }

        public override string ToString()
        {
            return $"Truck: {this.fuelQuantity:f2}";
        }
    }
}
