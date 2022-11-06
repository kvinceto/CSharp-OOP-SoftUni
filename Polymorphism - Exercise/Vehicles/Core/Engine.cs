namespace Vehicles.Core
{
    using System;

    using Models;
    using Interfaces;
    using Vehicles.IO.Interfaces;
    using Vehicles.Models.Interfaces;

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
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            string[] truckInfo = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            ExecuteCommands(car, truck);

            PrintResult(car, truck);
        }

        private void ExecuteCommands(Vehicle car, Vehicle truck)
        {
            int numberOfLines = int.Parse(reader.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] cmd = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (cmd[0])
                {
                    case "Drive":
                        Drive(cmd, car, truck);
                        break;
                    case "Refuel":
                        Refuel(cmd, car, truck);
                        break;
                }
            }
        }

        private void Drive(string[] cmd, Vehicle car, Vehicle truck)
        {
            switch (cmd[1])
            {
                case "Car":
                    writer.WriteLine(car.Drive(double.Parse(cmd[2])));
                    break;
                case "Truck":
                    writer.WriteLine(truck.Drive(double.Parse(cmd[2])));
                    break;
            }
        }

        private void Refuel(string[] cmd, Vehicle car, Vehicle truck)
        {
            switch (cmd[1])
            {
                case "Car":
                    car.Refuel(double.Parse(cmd[2]));
                    break;
                case "Truck":
                    truck.Refuel(double.Parse(cmd[2]));
                    break;
            }
        }

        private void PrintResult(Vehicle car, Vehicle truck)
        {
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
        }
    }
}
