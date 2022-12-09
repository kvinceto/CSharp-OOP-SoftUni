using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        private string hotelName;
        private int category;
        private Room room;

        [SetUp]
        public void Setup()
        {
            this.hotelName = "Hotel";
            this.category = 1;
            this.hotel = new Hotel(hotelName, category);
            room = new Room(2, 10);
        }

        [Test]
        public void ConstructorWork()
        {
           Assert.IsNotNull(hotel);
        }

        [Test]
        public void GettersWork()
        {
            Assert.AreEqual(this.hotelName, this.hotel.FullName);
            Assert.AreEqual(this.category, this.hotel.Category);
            Assert.AreEqual(0, this.hotel.Turnover);
            Assert.IsNotNull(this.hotel.Bookings);
            Assert.IsNotNull(this.hotel.Rooms);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void FullNameSetterThrows(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.hotel = new Hotel(name, category);
            });
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(-1)]
        [TestCase(10)]
        public void CategorySetterThrows(int c)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.hotel = new Hotel(hotelName, c);
            });
        }

        [Test]
        public void AddWorks()
        {
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [TestCase(0, 1, 2, 100)]
        [TestCase(-1, 1, 2, 100)]
        [TestCase(1, -1, 2, 100)]
        [TestCase(1, 1, 0, 100)]
        public void BookThrows(int adults, int children, int residenceDuration, double budget)
        {
            this.hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() =>
            {
                this.hotel.BookRoom(adults, children, residenceDuration, budget);
            });
        }

        [Test]
        public void BookWorks()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 0, 2, 100);
            Assert.AreEqual(2 * room.PricePerNight, hotel.Turnover);
        }

        [Test]
        public void BookWorksNot()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(3, 0, 2, 30);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void BookWorks2()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 0, 2, 100);
            Assert.AreEqual(1, hotel.Bookings.Count);
        }
    }
}