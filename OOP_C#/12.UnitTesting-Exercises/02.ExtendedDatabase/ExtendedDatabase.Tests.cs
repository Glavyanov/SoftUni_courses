using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase databaseEx;
        private Person[] arr;
        [SetUp]
        public void Setup()
        {
            databaseEx = new ExtendedDatabase();
        }

        [Test]
        [TestCase(0)]
        [TestCase(15)]
        [TestCase(16)]
        public void Ctor_ShouldAcceptElementsLessOrEqualThan16(long count)
        {
            arr = new Person[count];
            for (long i = 0; i < count; i++)
            {
                Person person = new Person(i, i.ToString());
                arr[i] = person;
            }
            databaseEx = new ExtendedDatabase(arr);
            Assert.AreEqual(arr.Length, databaseEx.Count);
        }
        [Test]
        [TestCase(17)]
        [TestCase(100)]
        public void Ctor_ShouldThrowExceptionWhenItemsGreaterThan16(long count)
        {
            arr = new Person[count];
            var ex = Assert.Throws<ArgumentException>(() => new ExtendedDatabase(arr));
            Assert.That(ex.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }
        [Test]
        [TestCase(15)]
        [TestCase(16)]
        public void AddMethodShouldWorkingCorrectlyWithElemntsLessOrEqualThan16(long count)
        {
            for (long i = 0; i < count; i++)
            {
                Person person = new Person(i, i.ToString());
                databaseEx.Add(person);
            }
            Assert.AreEqual(count, databaseEx.Count);
        }
        [Test]
        [TestCase(16)]
        public void AddMethodShouldThrowsExceptionWhenAddElementsGreaterThan16(long count)
        {
            for (long i = 0; i < count; i++)
            {
                Person person = new Person(i, i.ToString());
                databaseEx.Add(person);
            }
            var ex = Assert.Throws<InvalidOperationException>(() => databaseEx.Add(new Person(count + 1, (count + 1).ToString())));
            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        [TestCase(123456789)]
        public void AddMethodShouldThrowsExceptionWhenTryToAddElemntsWithSameUsername(long count)
        {
            databaseEx.Add(new Person(count + 1, count.ToString()));
            var ex = Assert.Throws<InvalidOperationException>(() => databaseEx.Add(new Person(count, count.ToString())));
            Assert.That(ex.Message, Is.EqualTo("There is already user with this username!"));

        }
        [Test]
        [TestCase(123456789)]
        public void AddMethodShouldThrowsExceptionWhenTryToAddElemntsWithSameId(long count)
        {
            databaseEx.Add(new Person(count, (count+1).ToString()));
            var ex = Assert.Throws<InvalidOperationException>(() => databaseEx.Add(new Person(count, count.ToString())));
            Assert.That(ex.Message, Is.EqualTo("There is already user with this Id!"));

        }
        [Test]
        [TestCase(3)]
        public void RemoveMethodShouldWorkCorectlyWhenTryToRemoveElementsFromArrayWithCountGreaterThanZero(long count)
        {
            databaseEx.Add(new Person(count, count.ToString()));
            databaseEx.Add(new Person(count+1, (count+1).ToString()));
            databaseEx.Add(new Person(count+2, (count+2).ToString()));
            databaseEx.Remove();
            Assert.AreEqual(databaseEx.Count, count - 1);
        }
        [Test]
        public void RemoveMethodShouldThrowsExceptionWhenTryToRemoveFromEmptyArray()
        {
            Assert.Throws<InvalidOperationException>(() => databaseEx.Remove());
        }
        [Test]
        [TestCase(0,"Test")]
        [TestCase(1111111111, "test")]
        public void FindByUsernameMethodShouldWorkCorrectlyAndCasesensitive(long count, string userName)
        {
            databaseEx.Add(new Person(count, userName));
            databaseEx.Add(new Person(count + 1, userName.ToUpper()));
            var person = databaseEx.FindByUsername(userName);
            Assert.AreEqual(userName, person.UserName);
        }
        [Test]
        [TestCase(0, "Test")]
        public void FindByUsernameShouldThrowsExceptionWhenTryToFindPersonWhoseUserNameIsNotInArray(long count, string userName)
        {
            databaseEx.Add(new Person(count + 1, userName.ToUpper()));
            var ex = Assert.Throws<InvalidOperationException>(() => databaseEx.FindByUsername(userName));
            Assert.That(ex.Message, Is.EqualTo("No user is present by this username!"));
        }
        [Test]
        [TestCase(0, "Test")]
        public void FindByUsernameShouldThrowsExceptionWhenTryToFindUserWithNullArgument(long count, string userName)
        {
            databaseEx.Add(new Person(count + 1, userName.ToUpper()));
            var ex = Assert.Throws<ArgumentNullException>(() => databaseEx.FindByUsername(null));
            Assert.That(ex.ParamName, Is.EqualTo("Username parameter is null!"));
        }
        [Test]
        [TestCase(0, "Test")]
        [TestCase(112345689, "test")]
        public void FindByIdMethodShouldWorkCorrectly(long count, string userName)
        {
            databaseEx.Add(new Person(count, userName));
            databaseEx.Add(new Person(count + 1, userName.ToUpper()));
            var person = databaseEx.FindById(count);
            Assert.AreEqual(count, person.Id);
        }
        [Test]
        [TestCase(0, "Test")]
        [TestCase(112345689, "test")]
        public void FindByIdMethodShouldThrowsExceptionWhenTryToFindNonExistingPerson(long count, string userName)
        {
            databaseEx.Add(new Person(count, userName));
            databaseEx.Add(new Person(count + 1, userName.ToUpper()));
            var ex = Assert.Throws<InvalidOperationException>(() => databaseEx.FindById(count + 2));
            Assert.That(ex.Message, Is.EqualTo("No user is present by this ID!"));
        }
        [Test]
        [TestCase(0, "Test")]
        [TestCase(112345689, "test")]
        public void FindByIdMethodShouldThrowsExceptionWhenTryToFindWithNegativeId(long count, string userName)
        {
            databaseEx.Add(new Person(count, userName));
            databaseEx.Add(new Person(count + 1, userName.ToUpper()));
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => databaseEx.FindById(count - (count * 2) - 1));
            Assert.That(ex.ParamName, Is.EqualTo("Id should be a positive number!"));
        }


    }
}