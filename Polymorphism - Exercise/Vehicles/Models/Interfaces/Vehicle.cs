namespace Vehicles.Models.Interfaces
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumptionPerKm;
        protected double fuelConsumptionOfConditioners;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public abstract string Drive(double distance);

        public abstract void Refuel(double liters);
    }
}
