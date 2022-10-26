
namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 3;
        }

        public new double DefaultFuelConsumption  { get; set; }
        public override void Drive(double kilometers)
        {
            double fuel = kilometers * DefaultFuelConsumption;
            Fuel -= fuel;
        }
    }
}
