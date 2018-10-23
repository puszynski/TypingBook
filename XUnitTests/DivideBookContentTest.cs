using BLLLibrary.Helpers;
using Xunit;

namespace XUnitTests
{
    /// <summary>
    /// Warunki podziału: 
    /// Po 200 znakach(W tym spacje i znaki specialne): wyszukaj w obrębie 200 znaków i przerwij: 
    ///     - if - kropka + spacja (włącz wielokropek, usuń spacje po)
    ///     - else - wyszukaj kropki (włącz wielokropek)
    ///     - else - przecinek + spacja
    ///     - else - pierwszy przecinek
    ///     - else - spacja
    ///         
    ///     If kropka/przecinek + spacja -> zakończ pierwszą sekcje za kropką - drugą rozpocznij bez spacji jeśli taka/takie były za kropką
    ///     **gdy wielokropek, po nim
    ///     If kropka/przecinek -> analogicznie
    ///     If spacja -> zakończ bez spacji; drugą rozpocznij bez spacji
    ///     If brak spacji -> perwij po 70 znaku; drugą rozpocznij po po;
    ///     
    ///     Kolejne sekcje analogiczne podziały jak dla pierwszego
    /// </summary>
    public class DivideBookContentTest
    {
        private readonly BookHelper _bookHelper = new BookHelper();
        
        [Fact]
        public void IsDivideCorrectNormalMode()
        {
            // Arrange
            DALLibrary.DomainModel.Book book = new DALLibrary.DomainModel.Book()
            {
                ID = 1,
                Title = "TitleTest",
                Author = "AuthorTest",
                Content = "In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters. Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless. He’d grown up, I learned, in an affluent suburb of Washington, D.C., where he’d excelled academically and had been an elite athlete. Immediately after graduating, with honors, from Emory University in the summer of 1990, McCandless dropped out of sight. He changed his name, gave the entire balance of a twenty-four-thousand-dollar savings account to charity, abandoned his car and most of his possessions, burned all the cash in his wallet. And then he invented a new life for himself, taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience. His family had no idea where he was or what had become of him until his remains turned up in Alaska."
            };

            // Act
            var devidedContentList = _bookHelper.DivideBook(book.Content);

            // Assert
            Assert.Equal("In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters.", devidedContentList[0]);
            Assert.Equal("Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless.", devidedContentList[1]);
            Assert.Equal("He’d grown up, I learned, in an affluent suburb of Washington, D.C., where he’d excelled academically and had been an elite athlete. Immediately after graduating, with honors, from Emory University in the summer of 1990, McCandless dropped out of sight.", devidedContentList[2]);
            Assert.Equal("He changed his name, gave the entire balance of a twenty-four-thousand-dollar savings account to charity, abandoned his car and most of his possessions, burned all the cash in his wallet. And then he invented a new life for himself, taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience.", devidedContentList[3]);
            Assert.Equal("His family had no idea where he was or what had become of him until his remains turned up in Alaska.", devidedContentList[4]);
        }


        [Fact]
        public void IsDivideCorrectNormalModeEqual200Chart()
        {
            // Arrange
            DALLibrary.DomainModel.Book book = new DALLibrary.DomainModel.Book()
            {
                ID = 1,
                Title = "TitleTest",
                Author = "AuthorTest",
                Content = "In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters. Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless. He’d grown up, I learned, in an affluent suburb of Washington, D.C., where he’d excelled academically and had been an elite athlete. Immediately after graduating, with honors, from Emory University in the summer of 1990, McCandless dropped out of sight. He changed his name, gave the entire balance of a twenty-four-thousand-dollar savings account to charity, abandoned his car and most of his possessions, burned all the cash in his wallet. And then he invented a new life for himself, taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience experience experience experience exp."
            };

            // Act
            var devidedContentList = _bookHelper.DivideBook(book.Content);

            // Assert
            Assert.Equal("In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters.", devidedContentList[0]);
            Assert.Equal("Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless.", devidedContentList[1]);
            Assert.Equal("He’d grown up, I learned, in an affluent suburb of Washington, D.C., where he’d excelled academically and had been an elite athlete. Immediately after graduating, with honors, from Emory University in the summer of 1990, McCandless dropped out of sight.", devidedContentList[2]);
            Assert.Equal("He changed his name, gave the entire balance of a twenty-four-thousand-dollar savings account to charity, abandoned his car and most of his possessions, burned all the cash in his wallet. And then he invented a new life for himself, taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience experience experience experience exp.", devidedContentList[3]);           
        }


        [Fact]
        public void IsDivideCorrectMultiDots()
        {
            // Arrange
            DALLibrary.DomainModel.Book book = new DALLibrary.DomainModel.Book()
            {
                ID = 1,
                Title = "TitleTest",
                Author = "AuthorTest",
                Content = "In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters... Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless."
            };

            // Act
            var devidedContentList = _bookHelper.DivideBook(book.Content);

            // Assert
            Assert.Equal("In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters...", devidedContentList[0]);
            Assert.Equal("Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless.", devidedContentList[1]);
        }
    }
}
