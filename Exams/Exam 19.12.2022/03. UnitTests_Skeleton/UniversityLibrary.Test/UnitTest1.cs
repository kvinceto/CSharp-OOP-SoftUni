namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private TextBook book;
        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            book = new TextBook("A", "B", "C");
            library = new UniversityLibrary();
        }

        [Test]
        public void ConstructorWorks()
        {
            Assert.IsNotNull(library);
            Assert.IsNotNull(library.Catalogue);
            Assert.AreEqual(0, library.Catalogue.Count);
        }

        [Test]
        public void AddWorks()
        {
            string expected = $"Book: {book.Title} - {1}" + Environment.NewLine + $"Category: {book.Category}" + Environment.NewLine + $"Author: {book.Author}";
            string actual = library.AddTextBookToLibrary(book);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, book.InventoryNumber);
            Assert.AreEqual(1, library.Catalogue.Count);
        }

        [Test]
        public void LoanWorks()
        {
            string name = "Ivan";
            library.AddTextBookToLibrary(book);
            string expected = $"{book.Title} loaned to {name}.";
            string actual = library.LoanTextBook(1, name);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(name, book.Holder);

            expected = $"{name} still hasn't returned {book.Title}!";
            actual = library.LoanTextBook(1, name);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnWorks()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, "Ivan");
            string expected = $"{book.Title} is returned to the library.";
            string actual = library.ReturnTextBook(1);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(string.Empty, book.Holder);

        }
    }
}