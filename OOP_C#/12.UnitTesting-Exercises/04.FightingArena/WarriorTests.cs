using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private int minAttackHp = 30;
        private string name = "War";
        private int damage = 50;
        private int hp = 50;
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void Ctor_ShouldProperlySetProperties()
        {
            Assert.IsNotNull(warrior);
        }

        [Test]
        [TestCase("Warm")]
        public void NamePropShouldSetValueIfIsNotNullOrEmptyOrWhiteSpace(string testName)
        {
            warrior = new Warrior(testName, damage, hp);
            Assert.AreEqual(testName, warrior.Name);
        }
        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void NamePropShouldThrowsExceptionIfValueIsNullOrEmptyOrWhiteSpace(string testName)       
        {
            Assert.Throws<ArgumentException>(() => new Warrior(testName, damage, hp), "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(90)]
        public void DamagePropShouldSetValueIfIsNotLessOrEqualThanZero(int testDamage)
        {
            warrior = new Warrior(name, testDamage, hp);
            Assert.AreEqual(testDamage, warrior.Damage);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DamagePropShouldThrowsExceptionIfValueIfIsLessOrEqualThanZero(int testDamage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, testDamage, hp), "Damage value should be positive!");
        }

        [Test]
        [TestCase(90)]
        public void HPPropShouldSetValueIfIsNotLessThanZero(int testHp)
        {
            warrior = new Warrior(name, damage, testHp);
            Assert.AreEqual(testHp, warrior.HP);
        }
        [Test]
        [TestCase(-25)]
        [TestCase(-1)]
        public void HPPropShouldThrowsExceptionIfValueIfIsLessThanZero(int testHp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, testHp), "HP should not be negative!");
        }

        [Test]
        [TestCase(40)]
        [TestCase(50)]
        public void AttackMethodShouldWorkCorrectlyAndAfterAttackBothHpEqualToZero(int health)
        {
            Warrior enemy = new Warrior("enemy", 50, health);
            warrior.Attack(enemy);
            bool condition = warrior.HP == 0 && enemy.HP == 0;
            Assert.IsTrue(condition);
        }
        [Test]
        [TestCase(100)]
        [TestCase(200)]
        public void AttackMethodShouldWorkCorrectly(int health)
        {
            Warrior enemy = new Warrior("enemy", 50, health);
            int currentEnemyHp = enemy.HP;
            warrior.Attack(enemy);
            Assert.AreEqual(enemy.HP, currentEnemyHp - warrior.Damage);
            
        }
        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodSouldThrowsExceptionWhenHPWarriorIsLessOrEqualToMinAttackHP(int testHp)
        {
            warrior = new Warrior(name, damage, testHp);
            Warrior enemy = new Warrior("enemy", 20, 50);
            var ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.That(ex.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }
        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodSouldThrowsExceptionWhenHPEnemyIsLessOrEqualToMinAttackHP(int testHp)
        {
            warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior("enemy", 20, testHp);
            var ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.That(ex.Message, Is.EqualTo($"Enemy HP must be greater than {minAttackHp} in order to attack him!"));
        }
        [Test]
        [TestCase(51)]
        [TestCase(100)]
        public void AttackMethodSouldThrowsExceptionWhenTryAttackStrongerEnemy(int testDamage)
        {
            warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior("enemy", testDamage, 50);
            var ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
            Assert.That(ex.Message, Is.EqualTo($"You are trying to attack too strong enemy"));
        }
    }
}