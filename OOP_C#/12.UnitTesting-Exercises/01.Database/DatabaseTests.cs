using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Ctor_CreateDatabase()
        {
            this.database = new Database();
        }

        [Test]
        [TestCase(0)]
        [TestCase(15)]
        [TestCase(16)]
        public void Ctor_ShouldAcceptElementsLessOrEqualThan16(int count)
        {
            int[] arr = new int[count];
            database = new Database(arr);
            Assert.AreEqual(arr.Length, database.Count);
        }
        [Test]
        [TestCase(17)]
        [TestCase(100)]
        public void Ctor_ShouldThrowExceptionWhenItemsGreaterThan16(int count)
        {
            int[] arr = new int[count];
            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }
        [Test]
        [TestCase(4)]
        [TestCase(16)]
        public void AddMethodShouldAddItemsLessThanOrEqualTo16(int count)
        {
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(16)]
        public void AddMethodShouldThrowsExceptionWhenAddItemsGreaterThan16(int count)
        {
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(count));
        }

        [Test]
        [TestCase(5)]
        public void RemoveMethodShouldRemoveElementsWhenCountGreaterThanZero(int count)
        {
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            database.Remove();
            Assert.AreEqual(count - 1, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenTryToRemoveFromEmptyCollection()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FetchMethodShouldReturnTheElementsAsAnArray()
        {
            for (int i = 0; i < 3; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(database.Fetch(), (new int[] { 0, 1, 2 }));
        }
    }
}