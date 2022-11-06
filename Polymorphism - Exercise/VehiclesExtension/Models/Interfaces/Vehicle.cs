namespace VehiclesExtension.Models.Interfaces
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumptionPerKm;
        protected double fuelConsumptionOfConditioners;
        protected double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.tankCapacity = tankCapacity;
        }

        protected abstract double FuelCheck(double fuelToAdd);

        public abstract string Drive(double distance);

        public abstract void Refuel(double liters);

    }
}
