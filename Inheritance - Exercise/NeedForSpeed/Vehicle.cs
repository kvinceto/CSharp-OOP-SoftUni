
namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            DefaultFuelConsumption = 1.25;
        }
        public double DefaultFuelConsumption  { get; set; }
        public double Fuel  { get; set; }
        public int HorsePower  { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuel = kilometers * DefaultFuelConsumption;
            Fuel -= fuel;
        }
    }
}
