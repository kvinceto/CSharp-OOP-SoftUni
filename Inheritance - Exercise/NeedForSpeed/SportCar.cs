
namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 10;
        }
        public new double DefaultFuelConsumption { get; set; }
        public override void Drive(double kilometers)
        {
            double fuel = kilometers * DefaultFuelConsumption;
            Fuel -= fuel;
        }
    }
}
