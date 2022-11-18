using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private Axe axe;
        private int attack;
        private int durability;

        [SetUp]
        public void SetUp()
        {
            attack = 10;
            durability = 5;
            dummy = new Dummy(15, 10);
            axe = new Axe(attack, durability);
        }

        [Test]
        public void AxeHasToLoseDurabilityAfterEachAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(4, axe.DurabilityPoints);
        }

        [Test]
        public void AttackWithBrokenAxeMustFail()
        {
            axe = new Axe(attack, 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}