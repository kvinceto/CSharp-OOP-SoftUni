using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] numbers;
        private Random random;
        private Database database;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            numbers = new int[16];
            for (int i = 0; i < numbers.Length; i++)
            {
                int n = random.Next(int.MinValue, int.MaxValue);
                numbers[i] = n;
            }
        }

        [Test]
        public void CreateDatabaseOfIntegersWith_16_Elements()
        {
            database = new Database(numbers);
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void FailToCreateDatabaseWithMoreThan_16_Integers()
        {
            numbers = new int[17];
            for (int i = 0; i < numbers.Length; i++)
            {
                int n = random.Next(int.MinValue, int.MaxValue);
                numbers[i] = n;
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(numbers);
            });
        }

        [Test]
        public void AddMethodShouldAddIntegerToTheLastAvailableIndex()
        {
            int n = random.Next(int.MinValue, int.MaxValue);
            int m = random.Next(int.MinValue, int.MaxValue);
            int p = random.Next(int.MinValue, int.MaxValue);
            int x = random.Next(int.MinValue, int.MaxValue);

            database = new Database(n, m, p);
            database.Add(x);
            int[] arr = database.Fetch();
            int result = arr[3];
            Assert.AreEqual(x, result);
        }

        [Test]
        public void AddMethodFailsToAddIntegerAd()
        {
            database = new Database(numbers);
            int n = random.Next(int.MinValue, int.MaxValue);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(n);
            });
        }

        [Test]
        public void RemoveMethodFailsToRemoveFromEmptyDatabase()
        {
            database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void RemoveMethodRemovesIntegerFromLastIndexAvailable()
        {
            database = new Database(numbers);
            database.Remove();
            int[] arrAfterRemoval = database.Fetch();

            Assert.AreEqual(15, arrAfterRemoval.Length);
        }

        [Test]
        public void FetchMethodReturnsArrayOfIntegers()
        {
            database = new Database(numbers);
            int [] arr = database.Fetch();
            Assert.AreEqual(numbers, arr);
        }
    }
}
