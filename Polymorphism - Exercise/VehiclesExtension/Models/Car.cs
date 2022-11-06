namespace VehiclesExtension.Models
{
    using System;

    using Interfaces;

    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.fuelConsumptionOfConditioners = 0.9;
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

            if (this.fuelQuantity >= fuelNeeded)
            {
                this.fuelQuantity -= fuelNeeded;
                return $"Car travelled {distance} km";
            }

            return $"Car needs refueling";
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.fuelQuantity + liters > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"Car: {this.fuelQuantity:f2}";
        }
    }
}
