using System;
using System.Linq;
using NUnit.Framework;



    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstrstructorShouldBeInitializedWith16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();

            Database database = new Database(numbers);

            var expResult = 16;
            var actResult = database.Count;

            Assert.AreEqual(expResult, actResult);

        }

        [Test]
        public void ConstrstructorShouldThrowExceptionIfThereAreNot16Elements()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(numbers);

            var expResult = 10;
            var actResult = database.Count;

            Assert.AreEqual(expResult, actResult);

        }
        [Test]
        public void AddOperationShouldAddElementAtTheNextFreeCell()
        {
            //Arange
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(numbers);

            //Act
            database.Add(5);

            var allElements = database.Fetch();

            //Assert
            var expValue = 5;
            var actValue = allElements[10];

            var expCount = 11;
            var actCount = database.Count;

        Assert.AreEqual(expValue, actValue);

        Assert.AreEqual(expCount, actCount);
        }
        [Test]
        public void AddOperationShouldThrowExceptionIfelementsAreAbove16()
        {
            //Arange
            int[] numbers = Enumerable.Range(1, 16).ToArray();

            Database database = new Database(numbers);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(10));
        }

        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingElementAtLastIndex()
        {
            //Arange
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(numbers);

            //Act

            database.Remove();

            //Assert

            var expResult = 9;
            var actValue = database.Fetch()[8];


            var expCount = 9;
            var actCount = database.Count;

            Assert.AreEqual(expResult, actValue);
            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfDatabaseIsEmpty()
        {

            //Arrange
            Database database = new Database();

            //Act Assert

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllElements()
        {

            //Arange
            int[] numbers = Enumerable.Range(1, 5).ToArray();

            Database database = new Database(numbers);

            //Act
            var allItems = database.Fetch();

            //Assert

            int[] expValue = {1, 2, 3, 4, 5};

            CollectionAssert.AreEqual(expValue, allItems);
        }
    }
