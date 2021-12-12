using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DummyHealth = 20;
        private const int DummyXp = 20;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyXp);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {

            // Act
            dummy.TakeAttack(20);

            // Assert
            Assert.IsTrue(dummy.Health == 0);
        }
        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            dummy.TakeAttack(20);
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(20));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DeadDummyCanGiveXp()
        {
            dummy.TakeAttack(20);
            Assert.IsTrue(dummy.GiveExperience() == DummyXp);

        }
        [Test]
        public void AliveDummyCannotGiveXp()
        {
            dummy.TakeAttack(10);
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }

    }
}
