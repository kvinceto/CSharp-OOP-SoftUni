namespace Vehicles.Models
{
    using Interfaces;

    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
        {
            this.fuelConsumptionOfConditioners = 1.6;
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = (this.fuelConsumptionPerKm + this.fuelConsumptionOfConditioners)
                * distance;
            if (fuelNeeded <= this.fuelQuantity)
            {
                this.fuelQuantity -= fuelNeeded;
                return $"Truck travelled {distance} km";
            }

            return $"Truck needs refueling";
        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += 0.95 * liters;
        }

        public override string ToString()
        {
            return $"Truck: {this.fuelQuantity:f2}";
        }
    }
}
