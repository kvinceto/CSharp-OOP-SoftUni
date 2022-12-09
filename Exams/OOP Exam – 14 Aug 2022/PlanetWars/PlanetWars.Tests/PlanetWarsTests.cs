using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private string weaponName;
            private double weaponPrice;
            private int weaponDestructionlevel;
            private Planet planet;
            private string planetName;
            private double planetBudget;

            [SetUp]

            public void SetUp()
            {
                this.weaponName = "A";
                this.weaponPrice = 10;
                this.weaponDestructionlevel = 1;
                this.weapon = new Weapon(weaponName, weaponPrice, weaponDestructionlevel);
                this.planetName = "P1";
                this.planetBudget = 1000;
                this.planet = new Planet(planetName, planetBudget);
            }

            [Test]
            public void WeaponConstructorShouldCreateWeapon()
            {
                Assert.IsNotNull(weapon);
            }

            [Test]
            public void WeaponNameGetterAndSetterShouldWork()
            {
                Assert.AreEqual(weaponName, weapon.Name);
                weaponName = "B";
                weapon.Name = weaponName;
                Assert.AreEqual(weaponName, weapon.Name);
            }

            [Test]
            public void WeaponPriceGetterAndSetterShouldWork()
            {
                Assert.AreEqual(weaponPrice, weapon.Price);
                weaponPrice = 20;
                weapon.Price = weaponPrice;
                Assert.AreEqual(weaponPrice, weapon.Price);
            }

            [TestCase(-1)]
            [TestCase(-10)]
            public void WeaponPriceSetterShouldThrows(double newPrice)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    weapon.Price = newPrice;
                });
            }

            [Test]
            public void WeaponDSlevelGetterAndSetterShouldWork()
            {
                Assert.AreEqual(weaponDestructionlevel, weapon.DestructionLevel);
                weaponDestructionlevel = 2;
                weapon.DestructionLevel = weaponDestructionlevel;
                Assert.AreEqual(weaponDestructionlevel, weapon.DestructionLevel);
            }

            [Test]
            public void IncreaseDestructionLevelShouldWork()
            {
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(weaponDestructionlevel + 1, weapon.DestructionLevel);
            }

            [Test]
            public void IsNuclearGetterShouldWork()
            {
                Assert.IsFalse(weapon.IsNuclear);
                weapon.DestructionLevel = 20;
                Assert.IsTrue(weapon.IsNuclear);
            }

            [Test]
            public void PlanetConstructorShouldCreatePlanet()
            {
                Assert.IsNotNull(planet);
            }

            [Test]
            public void PlanetGetters()
            {
                Assert.AreEqual(planetName, planet.Name);
                Assert.AreEqual(planetBudget, planet.Budget);
            }

            [TestCase("")]
            [TestCase(null)]
            public void PlanetNameThrows(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(name, planetBudget);
                });
            }

            [TestCase(-1)]
            [TestCase(-10)]
            public void PlanetBudgetThrows(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(planetName, budget);
                });
            }

            [Test]
            public void PlanetWeaponsAddWorks()
            {
                planet.AddWeapon(weapon);
                CollectionAssert.IsNotEmpty(planet.Weapons);
            }

            [Test]
            public void PlanetWeaponsAddThrows()
            {
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
            }

            [Test]
            public void PlanetWeaponsRemoveWork()
            {
                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);
                CollectionAssert.IsEmpty(planet.Weapons);
            }

            [Test]
            public void PlanetProfitAddMoney()
            {
                double n = 100;
                planet.Profit(n);
                Assert.AreEqual(planetBudget + n, planet.Budget);
            }

            [Test]
            public void SpendFundsWorks()
            {
                double n = 10;
                planet.SpendFunds(n);
                Assert.AreEqual(planetBudget - n, planet.Budget);
            }

            [Test]
            public void SpendFundsThrows()
            {
                double n = 100000;
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(n);
                });
            }

            [Test]
            public void UpgradeWeaponWorks()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Assert.AreEqual(weaponDestructionlevel + 1, weapon.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponThrows()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weapon.Name);
                });
            }

            [Test]
            public void MilitaryPowerRatio()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(weaponDestructionlevel, planet.MilitaryPowerRatio);
            }

            [Test]
            public void DestructOpponentWorks()
            {
                planet.AddWeapon(weapon);
                Planet p2 = new Planet("2", 100);
                Weapon w2 = new Weapon("H", 20, 10);
                p2.AddWeapon(w2);
                string result = $"{planet.Name} is destructed!";
                Assert.AreEqual(result, p2.DestructOpponent(planet));
            }

            [Test]
            public void DestructOpponentThrows()
            {
                planet.AddWeapon(weapon);
                Planet p2 = new Planet("2", 100);
                Weapon w2 = new Weapon("H", 20, 10);
                p2.AddWeapon(w2);
                string result = $"{planet.Name} is destructed!";
                Assert.Throws<InvalidOperationException>(() =>
               {
                   planet.DestructOpponent(p2);
               });
            }
        }
    }
}
