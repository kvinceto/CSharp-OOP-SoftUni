using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorCreatesCollectionOfWarriors()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorToCollection()
        {
            Warrior warrior = new Warrior("Ivan", 40, 100);
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWarriorExistsInTheCollection()
        {
            Warrior warrior = new Warrior("Ivan", 40, 100);
            arena.Enroll(warrior);

            Warrior warrior2 = new Warrior("Ivan", 50, 80);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior2);
            }, "Warrior is already enrolled for the fights!)");
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWarriorExistsInTheCollectionSameWarrior()
        {
            Warrior warrior = new Warrior("Ivan", 40, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!)");
        }

        [Test]
        public void FightMethodShouldThrowExceptionMissingFighter()
        {
            Warrior attacker = new Warrior("Ivan", 40, 100);
            Warrior defender = new Warrior("Marin", 50, 100);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            string missingName = "John";
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(missingName, defender.Name);
            }, $"There is no fighter with name {missingName} enrolled for the fights!");

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, missingName);
            }, $"There is no fighter with name {missingName} enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldExecuteAttack()
        {
            Warrior attacker = new Warrior("Ivan", 40, 100);
            Warrior defender = new Warrior("Marin", 50, 100);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = attacker.HP - defender.Damage;
            int expectedDefenderHp = defender.HP - attacker.Damage;

            arena.Fight(attacker.Name, defender.Name);
            int actualAttackerHp = attacker.HP;
            int actualDefenderHp = defender.HP;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp);
        }

        [Test]
        public void CounterShouldWorkProperly()
        {
            Warrior w1 = new Warrior("Ivan", 40, 100);
            Warrior w2 = new Warrior("Marin", 50, 100);
            arena.Enroll(w1);
            arena.Enroll(w2);
            int expectedCount = 2;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void WarriorsGetterShouldReturnCollection()
        {
            Warrior w1 = new Warrior("Ivan", 40, 100);
            Warrior w2 = new Warrior("Marin", 50, 100);

            arena.Enroll(w1);
            arena.Enroll(w2);

            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(w1);
            warriors.Add(w2);

            var result = arena.Warriors.ToList();
            CollectionAssert.AreEqual(warriors, result);
        }
    }
}
