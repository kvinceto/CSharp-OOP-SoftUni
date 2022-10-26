
namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 8;
        }

        public new double DefaultFuelConsumption  { get; set; }
        public override void Drive(double kilometers)
        {
            double fuel = kilometers * DefaultFuelConsumption;
            Fuel -= fuel;
        }
    }
}
