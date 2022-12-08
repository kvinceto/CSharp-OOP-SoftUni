using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private string carModel;
            private int issues;
            private Car car;
            private Garage garage;
            private string name;
            private int people;

            [SetUp]
            public void SetUp()
            {
                carModel = "BMW";
                issues = 2;
                car = new Car(carModel, issues);
                name = "Zebra";
                people = 3;
                garage = new Garage(name, people);
            }

            [Test]
            public void ConstructorCreatesGarage()
            {
                Assert.IsNotNull(garage);
            }

            [Test]
            public void GettersWork()
            {
                Assert.AreEqual(name, garage.Name);
                Assert.AreEqual(people, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [TestCase(null)]
            [TestCase("")]
            public void SetterNameTrows(string newName)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    garage = new Garage(newName, people);
                });
            }

            [TestCase(0)]
            [TestCase(-1)]
            public void SetterMechanicsAvailableTrows(int n)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage(name, n);
                });
            }

            [Test]
            public void AddCarTrows()
            {
                garage = new Garage(name, 1);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car);
                });
            }

            [Test]
            public void AddCarWork()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void FixCarTrows()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(carModel);
                });
            }

            [Test]
            public void FixCarWork()
            {
                garage.AddCar(car);
                var result = garage.FixCar(carModel);
                Assert.AreEqual(0, result.NumberOfIssues);
                Assert.IsTrue(result.IsFixed);
                Assert.AreEqual(car, result);
            }

            [Test]
            public void RemoveFixedCarTrows()
            {
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    var n = garage.RemoveFixedCar();
                });
            }

            [Test]
            public void RemoveFixedCarWork()
            {
                garage.AddCar(car);
                var c = garage.FixCar(carModel);
                int expected = 1;
                int result = garage.RemoveFixedCar();

                Assert.AreEqual(expected, result);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void ReportWork()
            {
                garage.AddCar(car);
                string result = garage.Report();
                string expected = $"There are {1} which are not fixed: {carModel}.";

                Assert.AreEqual(expected, result);
            }
        }
    }
}