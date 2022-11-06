namespace VehiclesExtension.Core
{
    using System;

    using Interfaces;
    using Models;
    using VehiclesExtension.IO.Interfaces;
    using VehiclesExtension.Models.Interfaces;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carInfo = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(
                double.Parse(carInfo[1]),
                double.Parse(carInfo[2]),
                double.Parse(carInfo[3]));

            string[] truckInfo = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(
                double.Parse(truckInfo[1]),
                double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));
            string[] busInfo = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(
                double.Parse(busInfo[1]),
                double.Parse(busInfo[2]),
                double.Parse(busInfo[3]));

            ExecuteCommands(car, truck, bus);

            PrintResult(car, truck, bus);
        }

        private void ExecuteCommands(Vehicle car, Vehicle truck, Bus bus)
        {
            int numberOfLines = int.Parse(reader.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] cmd = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (cmd[0])
                    {
                        case "Drive":
                            Drive(cmd, car, truck, bus);
                            break;
                        case "DriveEmpty":
                            writer.WriteLine(bus.DriveEmpty(double.Parse(cmd[2])));
                            break;
                        case "Refuel":
                            Refuel(cmd, car, truck, bus);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
        }

        private void Drive(string[] cmd, Vehicle car, Vehicle truck, Bus bus)
        {
            switch (cmd[1])
            {
                case "Car":
                    writer.WriteLine(car.Drive(double.Parse(cmd[2])));
                    break;
                case "Truck":
                    writer.WriteLine(truck.Drive(double.Parse(cmd[2])));
                    break;
                case "Bus":
                    writer.WriteLine(bus.Drive(double.Parse(cmd[2])));
                    break;
            }
        }

        private void Refuel(string[] cmd, Vehicle car, Vehicle truck, Bus bus)
        {
            switch (cmd[1])
            {
                case "Car":
                    car.Refuel(double.Parse(cmd[2]));
                    break;
                case "Truck":
                    truck.Refuel(double.Parse(cmd[2]));
                    break;
                case "Bus":
                    bus.Refuel(double.Parse(cmd[2]));
                    break;
            }
        }

        private void PrintResult(Vehicle car, Vehicle truck, Bus bus)
        {
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
            writer.WriteLine(bus.ToString());
        }
    }
}
