namespace VehiclesExtension.Models
{
    using System;

    using Interfaces;

    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.fuelConsumptionOfConditioners = 1.4;
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

            if (fuelNeeded > this.fuelQuantity)
            {
                return "Bus needs refueling";
            }

            this.fuelQuantity -= fuelNeeded;
            return $"Bus travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = this.fuelConsumptionPerKm * distance;

            if (fuelNeeded > this.fuelQuantity)
            {
                return "Bus needs refueling";
            }

            this.fuelQuantity -= fuelNeeded;
            return $"Bus travelled {distance} km";
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
            return $"Bus: {this.fuelQuantity:f2}";
        }
    }
}
