using System;
using System.Collections.Generic;
using DB;
using NUnit.Framework;


namespace DB.Tests
{

    [TestFixture]
    public class DatabaseTests
    {
        private const string ErrorMessageForDifferentCount = "Database have {0}count different than input collection";

        [Test]
        public void DatabaseCapacityIsSixteen()
        {
            Database db = new Database(new List<int>() { 1, 2 });

            Assert.AreEqual(16, db.Capacity, "Capacity must be 16");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(6)]
        [TestCase(16)]
        public void DatebaseContructorWorkWithValidNumberOfElements(int count)
        {
            //Arrange
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            //Act
            Database db = new Database(list);

            //Assert
            Assert.AreEqual(count, db.Count, string.Format(ErrorMessageForDifferentCount, count));
        }

        [Test]
        [TestCase(17)]
        public void DatebaseContructorWorkWithInvalidNumberOfElements(int count)
        {
            //Arrange
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(list),
                "Database cannot be with size more than 16");
        }

        [Test]
        public void DatebaseContructorDoesntAcceptNullObject()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Database(null), "Database cannot be initilized with null");
        }

        [Test]
        public void DatebaseElementsReturnsValidCollection()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1, 2, 3 });

            //Assert
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, db.Elements);
            Assert.AreEqual(3, db.Count, string.Format(ErrorMessageForDifferentCount, 3));
        }

        [Test]
        public void DatabaseAddElement()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1 });

            //Act
            db.Add(2);

            //Assert
            Assert.AreEqual(2, db.Count, ErrorMessageForDifferentCount, 2);
        }

        [Test]
        public void DatabaseAddManyElements()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1 });

            //Act
            db.Add(2);
            db.Add(2);
            db.Add(2);

            //Assert
            Assert.AreEqual(4, db.Count, ErrorMessageForDifferentCount, 4);
        }

        [Test]
        [TestCase(16)]
        public void DatabaseAddMoreElementsThanCapacityOfDatabase(int count)
        {
            //Arrange
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
            Database db = new Database(list);

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(3), "Cannot add more elements than max capacity");
        }

        [Test]
        public void CheckIfAddedElementsIsLastElementInCollection()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1 });

            //Act
            db.Add(2);

            //Assert
            CollectionAssert.AreEqual(new int[] { 1, 2 }, db.Elements);
        }

        [Test]
        public void CheckIfAddedElementsAreLastInCollection()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1 });

            //Act
            db.Add(2);
            db.Add(3);
            db.Add(4);

            //Assert
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, db.Elements);
        }

        [Test]
        public void RemoveSingleElement()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1, 2, 3, 4 });

            //Act
            db.Remove();

            //Assert
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, db.Elements);
        }

        [Test]
        public void RemoveManyElements()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1, 2, 3, 4 });

            //Act
            db.Remove();
            db.Remove();
            db.Remove();

            //Assert
            CollectionAssert.AreEqual(new int[] { 1 }, db.Elements);
        }

        [Test]
        public void RemoveMoreElementsThanCollectionHave()
        {
            //Arrange
            Database db = new Database(new List<int>() { 1, 2 });

            //Act
            db.Remove();
            db.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

    }
}
