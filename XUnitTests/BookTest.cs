using Xunit;

namespace XUnitTests
{
    public class BookTest
    {
        [Fact] // Facts are tests which are always true. They test invariant conditions.
        public void AreEqualPassingTest()
        {
            Assert.Equal(4, 4);
        }
        

        [Theory] // Theories are tests which are only true for a particular set of data.
        [InlineData(4)]
        public void TheoryTest(int tastedData)
        {
            Assert.Equal(4, tastedData);
        }


        [Fact]
        public void BooksTest()
        {
            // Arrange
            DALLibrary.DomainModel.Book book = new DALLibrary.DomainModel.Book()
            {
                ID = 1,
                Title = "TitleTest",
                Author = "AuthorTest",
                Content = "ContentTest"                
            };
            // Act
            var testingValue = book.TitleAndAuthor();
            // Asser
            Assert.Equal(book.Title + " " +book.Author, testingValue);
        }
    }
}