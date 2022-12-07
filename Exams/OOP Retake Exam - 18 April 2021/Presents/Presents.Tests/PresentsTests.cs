using System;
using System.Collections.Generic;
using System.Linq;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private string presentName;
        private double presentMagic;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            presentName = "A";
            presentMagic = 10;
            present = new Present(presentName, presentMagic);
            bag = new Bag();
        }

        [Test]
        public void PresentConstructorWorks()
        {
            Assert.IsNotNull(present);
        }

        [Test]
        public void PresentGetterAndSetterWork()
        {
            Assert.AreEqual(presentName, present.Name);
            Assert.AreEqual(presentMagic, present.Magic);
            presentName = "B";
            present.Name = presentName;
            Assert.AreEqual(presentName, present.Name);
            presentMagic = 20;
            present.Magic = presentMagic;
            Assert.AreEqual(presentMagic, present.Magic);
        }

        [Test]
        public void BagConstructorWorks()
        {
            Assert.IsNotNull(bag);
        }

        [Test]
        public void CreateThrows1()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            }, "Present is null");
        }

        [Test]
        public void CreateThrows2()
        {
            string r = bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");
        }

        [Test]
        public void BagCreateWorks()
        {
            string expected = $"Successfully added present {present.Name}.";
            string result = bag.Create(present);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BagRemoveWorks()
        {
            bag.Create(present);
            bool result = bag.Remove(present);
            Assert.IsTrue(result);
            Assert.IsFalse(bag.Remove(present));
        }

        [Test]
        public void BagGetPresentWorks1()
        {
            bag.Create(present);
            Present result = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(present, result);
        }

        [Test]
        public void BagGetPresentWorks2()
        {
            bag.Create(present);
            Present result = bag.GetPresent(presentName);

            Assert.AreEqual(present, result);
        }

        [Test]
        public void BagGetPresentWorks2Null()
        {
            Present result = bag.GetPresent(presentName);

            Assert.IsNull(result);
        }

        [Test]
        public void BagGetPresentWorks3()
        {
            bag.Create(present);
            List<Present> expected = new List<Present> { present };
            List<Present> result = bag.GetPresents().ToList();

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
