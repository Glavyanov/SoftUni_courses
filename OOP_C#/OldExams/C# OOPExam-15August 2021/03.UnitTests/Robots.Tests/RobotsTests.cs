namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        RobotManager manager;
        
        [SetUp]
        public void Setup()
        {
            manager = new RobotManager(5);
        }

        [Test]
        public void Ctor_ShouldWorkCorrectly()
        {
            Assert.AreEqual(5, manager.Capacity);
        }
        [Test]
        public void Ctor_ShouldInitzializeCollection()
        {
            Assert.AreEqual(0,manager.Count);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Ctor_ShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(()=> manager = new RobotManager(capacity));
        }
        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            Robot robot = new Robot("Andro", 100);
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void AddMethodShouldThrowsExceptionWhenTryToAddSameRobot()
        {
            Robot robot = new Robot("Andro", 100);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot));
        }
        [Test]
        public void AddMethodShouldThrowsExceptionWhenTryToAddMoreRobots()
        {
            Robot robot = new Robot("Andro", 100);
            Robot robot1 = new Robot("Andro1", 100);
            Robot robot2 = new Robot("Andro2", 100);
            Robot robot3 = new Robot("Andro3", 100);
            Robot robot4 = new Robot("Andro4", 100);
            Robot robot5 = new Robot("Andro5", 100);
            manager.Add(robot);
            manager.Add(robot1);
            manager.Add(robot2);
            manager.Add(robot3);
            manager.Add(robot4);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot5));
        }
        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Robot robot = new Robot("Andro", 100);
            Robot robot2 = new Robot("Andro2", 100);
            manager.Add(robot);
            manager.Add(robot2);
            manager.Remove("Andro2");
            Assert.AreEqual(1, manager.Count);

        }
        [Test]
        public void RemoveMethodShouldThrowsExceptionWhenRemoveNonExistingRobot()
        {
            Assert.Throws<InvalidOperationException>(()=> manager.Remove("Andro"));

        }
        [Test]
        public void WorkMethodShouldWork()
        {
            Robot robot = new Robot("Andro", 100);
            manager.Add(robot);
            manager.Work("Andro", "....", 100);
            Assert.AreEqual(0, robot.Battery);
        }
        [Test]
        public void WorkMethodShouldThrows()
        {
            Robot robot = new Robot("Andro", 100);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Work("Androoo", "....", 50));
        }
        [Test]
        public void WorkMethodShouldThrowsExceptionMoreBatteryUsage()
        {
            Robot robot = new Robot("Andro", 100);
            manager.Add(robot);
            manager.Work("Andro", "....", 50);
            Assert.Throws<InvalidOperationException>(() => manager.Work("Andro", "....", 200));
        }
        [Test]
        public void ChargeMethodShouldWorkCorrectly()
        {
            Robot robot = new Robot("Andro", 100);
            manager.Add(robot);
            manager.Work("Andro", "....", 40);
            manager.Charge("Andro");
            Assert.AreEqual(100, robot.Battery);
        }
        [Test]
        public void ChargeMethodShouldThroesException()
        {
            Robot robot = new Robot("Andro", 100);
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Andro"));
        }
    }
}
