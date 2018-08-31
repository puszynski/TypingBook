using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BookDomainModelTest //wskazuje jaki kontroller(klasa) jest testowany(a) ?
    {
        [TestMethod]
        public void VerifyBook()
        {
            // arrange
            const int expectedID = 1;
            const string expectedTitle = "TestName";
            const string expectedAuthor = "TestAuthor";
            const string expectedContent = "TestContent";

            
            FakeBookRepository repositoryParam = new FakeBookRepository();
            repositoryParam.Book.Add(test01);
            // act
            var book = new Book()
            {
                ID = expectedID,
                Title = expectedTitle,
                Author = expectedAuthor,
                Content = expectedContent
            };

            // assert
            Assert.AreEqual();
        }
    }

    private class FakeBookRepository : IBookRepository
    {
        public List<Book> Books = new List<Book>();
        public bool DidSubmitChanges = false; 

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
