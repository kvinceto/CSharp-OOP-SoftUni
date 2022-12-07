namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private string bookName;
        private string author;
        private Book book;
        [SetUp]
        public void SetUp()
        {
            bookName = "Name";
            author = "Author";
            book = new Book(bookName, author);
        }

        [Test]
        public void ConstructorShouldCreateBook()
        {
            Assert.IsNotNull(book);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BookNameShouldThrows(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(name, author);
            });
        }

        [Test]
        public void BookNameShouldSetValue()
        {
            Assert.AreEqual(bookName, book.BookName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorShouldThrows(string input)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(bookName, input);
            });
        }

        [Test]
        public void AuthorShouldSetValue()
        {
            Assert.AreEqual(author, book.Author);
        }

        [Test]
        public void AddFootnoteShouldAdd()
        {
            book.AddFootnote(1, "note");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteShouldThrows()
        {
            book.AddFootnote(1, "note");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "text");
            });
        }

        [Test]
        public void FindFootnoteShouldReturnString()
        {
            book.AddFootnote(1, "note");
            string expected = $"Footnote #1: note";
            string result = book.FindFootnote(1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindFootnoteShouldThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                string result = book.FindFootnote(1);
            });
        }

        [Test]
        public void AlterFootnoteShouldReturnString()
        {
            book.AddFootnote(1, "note");
            string expected = $"Footnote #1: change";
            book.AlterFootnote(1, "change");
            string result = book.FindFootnote(1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AlterFootnoteThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(1, "text");
            });
        }
    }
}