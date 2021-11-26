using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Ctor_ShouldInitzializePropertyWarriors()
        {
            int count = arena.Warriors.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void CountPropertyShouldWorkCorrect()
        {
            int count = arena.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void EnrollMethodShouldWorkCorrectlyAndAddingWarrior()
        {
            Warrior warrior = new Warrior("Rocky", 50, 50);
            arena.Enroll(warrior);
            Assert.AreSame(warrior, arena.Warriors.FirstOrDefault(w => w.Name == warrior.Name));
        }
        [Test]
        public void EnrollMethodShouldWorkCorrectlyAndCountIsGreaterThanZero()
        {
            Warrior warrior = new Warrior("Rocky", 50, 50);
            Warrior warrior1 = new Warrior("Roko", 50, 50);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            Assert.AreEqual(2, arena.Warriors.Count);
        }
        [Test]
        [TestCase("Rocky")]
        [TestCase("Balboa")]
        public void EnrollMethodShoulThrowsExceptionWhenTryToAddWarriorWithSameName(string name)
        {
            Warrior warrior = new Warrior(name, 50, 50);
            arena.Enroll(warrior);
            var ex = Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(name, 100, 100)));
            Assert.That(ex.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightMethodShouldWorkCorrectly()
        {
            Warrior warriorA = new Warrior("Rocky", 50, 45);
            Warrior warriorB = new Warrior("Roko", 50, 50);
            Warrior warriorC = new Warrior("Rock", 45, 40);
            arena.Enroll(warriorA);
            arena.Enroll(warriorB);
            arena.Enroll(warriorC);
            arena.Fight("Rocky", "Rock");
            Assert.AreEqual(warriorA.HP, warriorC.HP);
        }
        [Test]
        [TestCase("RockAndRoll")]
        [TestCase(null)]
        [TestCase("")]
        public void FightMethodShouldThrowsExceptionWhenOneOfTheFightersMissinginTheList(string name)
        {
            Warrior warriorA = new Warrior("Rocky", 50, 45);
            Warrior warriorB = new Warrior("Roko", 50, 50);
            Warrior warriorC = new Warrior("Rock", 45, 40);
            arena.Enroll(warriorA);
            arena.Enroll(warriorB);
            arena.Enroll(warriorC);
            var ex = Assert.Throws<InvalidOperationException>(()=>arena.Fight("Rocky", name));
            Assert.That(ex.Message, Is.EqualTo($"There is no fighter with name {name} enrolled for the fights!"));
        }
    }
}
