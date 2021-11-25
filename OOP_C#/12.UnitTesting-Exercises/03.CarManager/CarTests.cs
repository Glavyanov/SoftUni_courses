using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private const string Make = "Audi";
        private const string Model = "A3";
        private const double FuelConsumption = 8.5;
        private const double FuelAmount = 0;
        private const double FuelCapacity = 50;
        private Car car; 

        [SetUp]
        public void CarInit()
        {
            car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void Ctor_ShouldCorrectlyInitzializesProperties()
        {
            Assert.IsNotNull(car,"Broken constructor");
        }

        [Test]
        public void AllPropertiesShouldSetCorrectly()
        {
            bool condition = car.Make == Make && Model == car.Model && FuelConsumption == car.FuelConsumption && FuelAmount == car.FuelAmount && FuelCapacity == car.FuelCapacity;
            Assert.IsTrue(condition);
        }

        [Test]
        public void MakePropertyWorkCorrectly()
        {
            Assert.AreEqual(car.Make, Make);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakePropertyShouldThrowsExceptionWhenValueIsNullOrEmptySpace(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, Model,FuelConsumption,FuelCapacity));
        }

        [Test]
        public void ModelPropertyWorkCorrectly()
        {
            Assert.AreEqual(car.Model, Model);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelPropertyShouldThrowsExceptionWhenValueIsNullOrEmptySpace(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car(Make, model, FuelConsumption, FuelCapacity));
        }

        [Test]
        public void FuelConsumptionPropertyWorkCorrectly()
        {
            Assert.AreEqual(car.FuelConsumption, FuelConsumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(0.0)]
        [TestCase(-0.0001)]
        [TestCase(-1.0)]
        public void FuelConsumptionPropertyShouldThrowsExceptionWhenValueIsNullOrEmptySpace(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car(Make, Model, fuelConsumption, FuelCapacity));
        }

        [Test]
        public void FuelAmountPropertyWorkCorrectly()
        {
            Assert.AreEqual(car.FuelAmount, FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(0.0)]
        [TestCase(-0.0001)]
        [TestCase(-1.0)]
        public void FuelAmountPropertyShouldThrowsExceptionWhenValueIsZeroOrNegative(double refuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(refuel));
        }

        [Test]
        public void FuelCapacityPropertyWorkCorrectly()
        {
            Assert.AreEqual(car.FuelCapacity, FuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(0.0)]
        [TestCase(-0.0001)]
        [TestCase(-1.0)]
        public void FuelCapacityPropertyShouldThrowsExceptionWhenValueIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(Make, Model, FuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(12)]
        [TestCase(0.1)]
        [TestCase(0.0001)]
        [TestCase(50)]
        public void RefuelMethodShouldWorkCorrectlyWhenFuelAmountIsZero(double refuel)
        {
            car.Refuel(refuel);
            Assert.AreEqual(refuel, car.FuelAmount);
        }

        [Test]
        [TestCase(200)]
        public void RefuelMethodShouldWorkCorrectlyWhenFuelAmountIsAboveFuelCapacity(double refuel)
        {
            car.Refuel(refuel);
            Assert.AreEqual(FuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(0.0)]
        [TestCase(-0.0001)]
        [TestCase(-1.0)]
        public void RefuelMethodShoulddThrowsExceptionWhenValueIsZeroOrNegative(double refuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(refuel));
        }

        [Test]
        [TestCase(100)]
        [TestCase(588)]
        public void DriveMethodShouldWorkCorrectly(double distance)
        {
            car.Refuel(FuelCapacity);
            car.Drive(distance);
            double totalFuelAmount = FuelCapacity - ((distance / 100) * FuelConsumption);
            Assert.AreEqual(totalFuelAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(1000)]
        [TestCase(700)]
        public void DriveMethodShouldThrowsExceptionWhenDistanceIsTooLong(double distance)
        {
            car.Refuel(FuelCapacity);
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}