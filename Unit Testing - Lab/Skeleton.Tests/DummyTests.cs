using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private int health;
        private int healthDead;
        private int experience;
        private Axe axe;
        private int attack;
        private int durability;

        [SetUp]
        public void SetUp()
        {
            health = 20;
            healthDead = -1;
            experience = 10;
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(healthDead, experience); 
            attack = 10; 
            durability = 5;
            axe = new Axe(attack, durability);
        }

        [Test]
        public void DummyLosesHeathAfterAttack()
        {
            dummy.TakeAttack(attack);
            Assert.AreEqual(10, dummy.Health);
        }

        [Test]
        public void DeathDummyAttackFails()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(attack);
            });
        }

        [Test]
        public void DeadDummyGivesExperience()
        {
            Assert.AreEqual(10, deadDummy.GiveExperience());
        }

        [Test]
        public void AliveDummyDoNotGivesExperience()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                int e = dummy.GiveExperience();
            });
        }
    }
}