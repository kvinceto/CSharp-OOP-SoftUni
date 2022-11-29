using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void SmartphoneConstructorShouldCreateSmartphoneWithValidData()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            Assert.AreEqual("LG", smartphone.ModelName);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void SmartphomeCurrentBateryChargeSetterShouldReduceValue()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            smartphone.CurrentBateryCharge -= 50;
            int expectedValue = 50;
            int actualValue = smartphone.CurrentBateryCharge;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void SmartphomeModelSetterShouldChangeValue()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            smartphone.ModelName = "Nokia";
            string expectedValue = "Nokia";
            string actualValue = smartphone.ModelName;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ShopConstructorShouldCreateShop()
        {
            Shop shop = new Shop(10);
            Assert.IsNotNull(shop);
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(100)]
        public void CapacityGetterShouldReturnCorrectValue(int capacity)
        {
            Shop shop = new Shop(capacity);
            Assert.AreEqual(capacity, shop.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void CapacitySetterShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [Test]
        public void AddMethodShouldAddSmartphoneToCollection()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddMethodShouldThrowException()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            }, $"The phone model {smartphone.ModelName} already exist.");
        }

        [Test]
        public void AddMethodShouldThrowExceptionForCapacity()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            Shop shop = new Shop(1);
            shop.Add(smartphone);

            Smartphone smartphone2 = new Smartphone("Nokia", 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone2);
            }, "The shop is full.");
        }

        [Test]
        public void RemoveMethodShouldThrowsException()
        {
            string modelName = "LG";
            Shop shop = new Shop(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }

        [Test]
        public void RemoveMethodShouldRemoveItem()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestPhoneMethodShouldThrowsExceptionNoPhoneFound()
        {
            string model = "LG";
            int bateryUsed = 20;
            Shop shop = new Shop(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(model, bateryUsed);
            }, $"The phone model {model} doesn't exist.");
        }

        [Test]
        public void TestPhoneMethodShouldThrowsExceptionBatteryToLow()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            smartphone.CurrentBateryCharge = 30;
            Shop shop = new Shop(10);
            shop.Add(smartphone);

            string model = "LG";
            int bateryUsed = 40;

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(model, bateryUsed);
            }, $"The phone model {model} is low on batery.");
        }

        [Test]
        public void TestPhoneMethodShouldReduceBateryLevel()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);

            string model = "LG";
            int bateryUsed = 40;

            shop.TestPhone(model, bateryUsed);
            int expectedValue = 100 - 40;
            int actualValue = smartphone.CurrentBateryCharge;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ChargeMethodShouldThrowsException()
        {
            string model = "LG";
            Shop shop = new Shop(10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(model);
            }, $"The phone model {model} doesn't exist.");
        }

        [Test]
        public void ChargeMethodShouldChargePhone()
        {
            Smartphone smartphone = new Smartphone("LG", 100);
            smartphone.CurrentBateryCharge = 50;
            Shop shop = new Shop(10);
            shop.Add(smartphone);

            shop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }
    }
}