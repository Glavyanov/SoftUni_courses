using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        ComputerManager manager;
        [SetUp]
        public void Setup()
        {
            manager = new ComputerManager();
        }

        [Test]
        public void Ctor_ComputerManagerShouldWorkCorrectly()
        {

            Assert.IsNotNull(manager.Computers);
        }
        [Test]
        public void CountReturnsCorrectData()
        {
            manager.AddComputer(new Computer("Dell", "Inter", 2000.01M));

            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void Ctor_ComputerManagerShouldCorrectlyInitzializeCollection()
        {

            Assert.AreEqual(0,manager.Count);
        }
        [Test]
        public void PropComputersShouldWorkCorrect()
        {
            Assert.AreEqual(0, manager.Computers.Count);
        }

        [Test]
        public void AddComputerMethodShouldWorkCorrectly()
        {
            Computer computer = new Computer("Dell", "Inter", 2000.01M);
            manager.AddComputer(computer);
            var comp = manager.GetComputer(computer.Manufacturer, computer.Model);
            Assert.AreSame(comp, computer);
        }
        [Test]
        public void AddComputerMethodShouldThrowsExceptionWhenAddExistingElement()
        {
            Computer computer = new Computer("Dell", "Inter", 2000.01M);
            manager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }
        [Test]
        public void AddComputerMethodShouldThrowsExceptionWhenAddExistingElementMessage()
        {
            Computer computer = new Computer("Dell", "Inter", 2000.01M);
            manager.AddComputer(computer);
            var message = Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
            Assert.That(message.Message, Is.EqualTo("This computer already exists."));
        }
        [Test]
        public void AddComputerMethodShouldThrowsExceptionWhenAddNullElement()
        {
            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(null));
        }
        [Test]
        public void AddComputerMethodShouldThrowsExceptionWhenAddNullElementMessage()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => manager.AddComputer(null));
            Assert.That(ex.Message, Is.EqualTo("Can not be null! (Parameter 'computer')"));

        }
        [Test]
        public void RemoveComputerMethodShouldWorkCorrectly()
        {
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("HP", "Expo", 2000.01M);
            manager.AddComputer(computerB);
            manager.AddComputer(computerA);
            var comp = manager.RemoveComputer("Dell", "Inter");
            Assert.AreSame(comp, computerA);
            Assert.AreEqual(1, manager.Computers.Count);
        }
        [Test]
        public void RemoveComputerMethodShouldWorkCountCorrectly()
        {
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("HP", "Expo", 2000.01M);
            manager.AddComputer(computerB);
            manager.AddComputer(computerA);
            var comp = manager.RemoveComputer("Dell", "Inter");
            Assert.AreEqual(1, manager.Computers.Count);
        }
        [Test]
        public void RemoveComputerMethodShouldWorkCorrectlyWhenRemoveElementAndCountDecrease()
        {
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("HP", "Expo", 2000.01M);
            manager.AddComputer(computerB);
            manager.AddComputer(computerA);
            var comp = manager.RemoveComputer("Dell", "Inter");
            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void GetComputerMethodShouldWorkCorrectly()
        {
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("HP", "Expo", 2000.01M);
            manager.AddComputer(computerB);
            manager.AddComputer(computerA);
            Assert.AreSame(manager.GetComputer("Dell", "Inter"), computerA);
        }
        [Test]
        public void GetComputerMethodShouldThrowsExceptionWhenElementIsNull()
        {
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("HP", "Expo", 2000.01M);
            manager.AddComputer(computerB);
            manager.AddComputer(computerA);
            Assert.Throws<ArgumentException>(() => manager.GetComputer("", " "));
        }
        [Test]
        public void GetComputerMethodShouldThrowsExceptionWhenElementIsNullMessage()
        {
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("HP", "Expo", 2000.01M);
            manager.AddComputer(computerB);
            manager.AddComputer(computerA);
            var ex = Assert.Throws<ArgumentException>(() => manager.GetComputer("Test", "tesT"));
            Assert.That(ex.Message, Is.EqualTo("There is no computer with this manufacturer and model."));

        }
        [Test]
        public void GetComputerMethodShouldThrowsExceptionWhenSecondParameterElementIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Dell", null));
        }
        [Test]
        public void GetComputerMethodShouldThrowsExceptionWhenFirstParameterElementIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "Inter"));
        }

        [Test]
        public void GetComputersByManufacturerMethodShouldWorkCorrectly()
        {
            ICollection<Computer> computers = new List<Computer>();
            Computer computerA = new Computer("Dell", "Inter", 2000.01M);
            Computer computerB = new Computer("Dell", "Expo", 5000.01M);
            computers.Add(computerA);
            computers.Add(computerB);
            manager.AddComputer(computerA);
            manager.AddComputer(computerB);
            var computersManager = manager.GetComputersByManufacturer("Dell");
            Assert.AreEqual(computers, computersManager);

        }
        [Test]
        public void GetComputersByManufacturerMethodShouldThrowsExceptionWhenFirstParameterElementIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));
        }
    }
}