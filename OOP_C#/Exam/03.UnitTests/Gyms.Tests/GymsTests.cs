using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        Gym gym;
        [SetUp]
        public void SetUp()
        {
            gym = new Gym("Club", 3);
        }
        [Test]
        public void Ctor_GymShouldWorkCorrectly()
        {
            Assert.IsNotNull(gym);
        }
        [Test]
        public void Ctor_GymShouldInitzializePropNameCorrect()
        {
            Assert.AreEqual("Club", gym.Name);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_GymShouldThrowsExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 2));
        }
        [Test]
        public void Ctor_GymShouldInitzializePropCapacityCorrect()
        {
            Assert.AreEqual(3, gym.Capacity);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Ctor_GymShouldThrowsExceptionWhenCapacityIsBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Gym("Club", capacity));
        }
        [Test]
        public void Ctor_ShouldInitzializeCollection()
        {
            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void AddAthleteMethodShouldWorkCorrect()
        {
            Athlete athlete = new Athlete("Rocky Balboa");
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void AddAthleteMethodShouldThrowsExceptionWhenCapacityIsOver()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            Athlete athleteC = new Athlete("Rocky Balboac");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            gym.AddAthlete(athleteC);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Rocky Balboad")));
        }
        [Test]
        public void RemoveAthleteMethodShouldWorkCorrect()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            gym.RemoveAthlete("Rocky Balboab");
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void RemoveAthleteMethodShoulThrowsExceptionWhenAthleteIsNull()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Rocky"));
        }
        [Test]
        public void InjureAthleteMethodShouldWorkCorrect()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            var athleteInjured = gym.InjureAthlete("Rocky Balboab");
            Assert.AreSame(athleteInjured, athleteB);
        }
        [Test]
        public void InjureAthleteMethodShouldInjuredCorrect()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            gym.InjureAthlete("Rocky Balboab");
            Assert.IsTrue(athleteB.IsInjured);
        }
        [Test]
        public void InjureAthleteMethodShouldThrowsExceptionWhenNoSuchAthlete()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Test"));
        }
        [Test]
        public void ReportMethodShouldWorkCorrect()
        {
            Athlete athleteA = new Athlete("Rocky Balboa");
            Athlete athleteB = new Athlete("Rocky Balboab");
            Athlete athleteC = new Athlete("Rocky Balboac");
            gym.AddAthlete(athleteA);
            gym.AddAthlete(athleteB);
            gym.AddAthlete(athleteC);
            gym.InjureAthlete("Rocky Balboab");
            string messageCorrect = $"Active athletes at {gym.Name}: Rocky Balboa, Rocky Balboac";
            Assert.That(messageCorrect, Is.EqualTo(gym.Report()));
        }
    }
}
