using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        RaceEntry race;
        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
        }

        [Test]
        public void Ctor_ShouldWorkCorrectly()
        {

            Assert.IsNotNull(race);
        }

        [Test]
        public void Ctor_ShouldCorrectlyInitializeCollection()
        {

            Assert.AreEqual(race.Counter, 0);
        }

        [Test]
        public void AddDriverMethodShouldAddCorrectlyDriver()
        {
            UnitCar car = new UnitCar("VW", 105, 1599.0);
            UnitDriver driver = new UnitDriver("Driver", car);
            race.AddDriver(driver);
            Assert.AreEqual(race.Counter, 1);
        }
        [Test]
        [TestCase("Driver")]
        [TestCase("Pilot")]
        public void AddDriverMethodShouldReturnMessageWhenAddCorrectlyDriver(string name)
        {
            UnitCar car = new UnitCar("VW", 105, 1599.0);
            UnitDriver driver = new UnitDriver(name, car);
            string message = race.AddDriver(driver);
            bool isEqual = message == $"Driver {driver.Name} added in race.";
            Assert.IsTrue(isEqual);
        }
        [Test]
        public void AddDriverMethodShouldThrowsExceprtionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }
        [Test]
        [TestCase("Driver")]
        [TestCase("Pilot")]
        public void AddDriverMethodShouldThrowsExceptionWhenTryingToAddExistingDriverInCollection(string name)
        {
            UnitCar car = new UnitCar("VW", 105, 1599.0);
            UnitDriver driver = new UnitDriver(name, car);
            string message = race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        [TestCase("Driver", "Pilot", 300)]
        [TestCase("Pilot", "Driver", 500)]
        public void CalculateAverageHorsePowerMethodShouldWorkCorrectly(string nameA, string nameB, int horse)
        {
            UnitCar carA = new UnitCar("VW", 100, 1599.0);
            UnitCar carB = new UnitCar("VW", horse, 1999.0);
            UnitDriver driverA = new UnitDriver(nameA, carA);
            UnitDriver driverB = new UnitDriver(nameB, carB);
            race.AddDriver(driverA);
            race.AddDriver(driverB);
            double result = race.CalculateAverageHorsePower();
            double testResult = (100 + horse) / 2.0;
            Assert.AreEqual(testResult, result);
        }
        [Test]
        [TestCase("Driver")]
        public void CalculateAverageHorsePowerMethodShouldThrowsExceprionWhenCollectionIsLessThanMinParticipants(string nameA)
        {
            UnitCar carA = new UnitCar("VW", 100, 1599.0);
            UnitDriver driverA = new UnitDriver(nameA, carA);
            race.AddDriver(driverA);
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());

        }
    }
}