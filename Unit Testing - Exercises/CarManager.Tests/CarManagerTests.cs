using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private double fuelAmount;
        private Car car;

        [Test]
        public void ConstructorShouldCreateCar()
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            fuelAmount = 0;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterShouldThrowException(string currentMake)
        {
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(currentMake, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterShouldThrowException(string currentModel)
        {
            make = "BMW";
            fuelConsumption = 10;
            fuelCapacity = 60;
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, currentModel, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void FuelConsumptionSetterShouldThrowException(double currentFuelConsumption)
        {
            make = "BMW";
            model = "X5";
            fuelCapacity = 60;

            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, currentFuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void FuelCapacitySetterShouldThrowException(double currentFuelCapacity)
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;

            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, currentFuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void RefuelMethodShouldThrowExceptionWithNegativeOrZeroFuelAmount(double currentFuelAmount)
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(currentFuelAmount);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(20)]
        [TestCase(60)]
        public void RefuelMethodShouldAddFuelToCar(double fuelToAdd)
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToAdd);
            double expectedFuelAmount = fuelToAdd;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(80)]
        [TestCase(100)]
        public void RefuelMethodShouldAddFuelToTheAmountForCapacity(double fuelToAdd)
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToAdd);
            double expectedFuelAmount = fuelCapacity;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWithNotEnoughFuel()
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double distance = 100;

            Assert.Throws<InvalidOperationException> (() =>
            {
                
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

        [Test]
        public void DriveMethodShouldReduceFuelAmount()
        {
            make = "BMW";
            model = "X5";
            fuelConsumption = 10;
            fuelCapacity = 60;
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            double distance = 100;
            double fuelToAdd = 20;

            car.Refuel(fuelToAdd);
            car.Drive(distance);

            double expectedFuelAmount = fuelToAdd - ((distance / 100) * fuelConsumption);
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

    }
}