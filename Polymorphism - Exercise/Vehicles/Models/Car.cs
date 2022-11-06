namespace Vehicles.Models
{
    using Interfaces;

    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
            this.fuelConsumptionOfConditioners = 0.9;
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = (this.fuelConsumptionPerKm + this.fuelConsumptionOfConditioners)
                * distance;
            if (this.fuelQuantity >= fuelNeeded)
            {
                this.fuelQuantity -= fuelNeeded;
                return $"Car travelled {distance} km";
            }

            return $"Car needs refueling";
        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"Car: {this.fuelQuantity:f2}";
        }
    }
}
