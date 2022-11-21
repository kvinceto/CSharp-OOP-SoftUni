using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;

        [Test]
        public void ConstructorShouldCreateWarrior()
        {
            name = "Ivan";
            damage = 40;
            hp = 100;
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("          ")]
        public void NameSetterShouldThrowException(string currentName)
        {
            damage = 40;
            hp = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(currentName, damage, hp);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void DamageSetterShouldThrowException(int currentDamage)
        {
            name = "Ivan";
            hp = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, currentDamage, hp);
            }, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void HpSetterShouldThrowException(int currentHp)
        {
            name = "Ivan";
            damage = 40;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, currentHp);
            }, "HP should not be negative!");
        }

        [TestCase(30)]
        [TestCase(1)]
        [TestCase(0)]
        public void AttackMethodShouldThrowExceptionWithInvalidHpAttacker(int currentHp)
        {
            name = "Ivan";
            damage = 40;
            
            Warrior warrior1 = new Warrior(name, damage, currentHp);

            name = "Marin";
            damage = 50;
            hp = 100;

            Warrior warrior2 = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(1)]
        [TestCase(0)]
        public void AttackMethodShouldThrowExceptionWithInvalidHpDefender(int currentHp)
        {
            name = "Ivan";
            damage = 40;
            hp = 100;

            Warrior warrior1 = new Warrior(name, damage, hp);

            name = "Marin";
            damage = 50;

            Warrior warrior2 = new Warrior(name, damage, currentHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(50)]
        [TestCase(60)]
        public void AttackMethodShouldThrowExceptionWithAttackerHpLowerThanDefenderDamage(int defenderDamage)
        {
            name = "Ivan";
            damage = 40;
            hp = 49;

            Warrior warrior1 = new Warrior(name, damage, hp);

            name = "Marin";
            hp = 100;

            Warrior warrior2 = new Warrior(name, defenderDamage, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            }, "You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackMethodShouldReduceHpAttacker()
        {
            name = "Ivan";
            damage = 40;
            hp = 100;

            Warrior warrior1 = new Warrior(name, damage, hp);

            name = "Marin";
            damage = 50;
            hp = 100;

            Warrior warrior2 = new Warrior(name, damage, hp);

            warrior1.Attack(warrior2);
            int expectedHpWarrior1 = 100 - 50;
            int w1Hp = warrior1.HP;

            Assert.AreEqual(expectedHpWarrior1, w1Hp);
        }

        [Test]
        public void AttackMethodShouldReduceHpDefender()
        {
            name = "Ivan";
            damage = 40;
            hp = 100;

            Warrior warrior1 = new Warrior(name, damage, hp);

            name = "Marin";
            damage = 50;
            hp = 100;

            Warrior warrior2 = new Warrior(name, damage, hp);

            warrior1.Attack(warrior2);
            int expectedHpWarrior2 = 100 - 40;
            int w2Hp = warrior2.HP;

            Assert.AreEqual(expectedHpWarrior2, w2Hp);
        }

        [TestCase(40)]
        [TestCase(35)]
        public void AttackMethodShouldReduceHpDefenderToZero(int defenderHp)
        {
            name = "Ivan";
            damage = 40;
            hp = 100;

            Warrior warrior1 = new Warrior(name, damage, hp);

            name = "Marin";
            damage = 50;

            Warrior warrior2 = new Warrior(name, damage, defenderHp);

            warrior1.Attack(warrior2);
            int expectedHpWarrior2 = 0;
            int w2Hp = warrior2.HP;

            Assert.AreEqual(expectedHpWarrior2, w2Hp);
        }
    }
}