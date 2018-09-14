using Xunit;

namespace XUnitTests
{
    public class DivideBookContentTest
    {
        /// <summary>
        /// Warunki podziału: Po 200 znakach(W tym spacje i znaki specialne) znajdź pierwszą kropkę+spacje i tam zakończ pierwszy człon
        ///     - If brak - wyszukaj kropki w przeciągo kolejnych 100
        ///     - If brak - pierwszy przecinek + spacja
        ///     - If brak - pierwszy przecinek
        ///     - If w przeciągu kolejnych 200 znaków brak kropki - zakończ po pierwszej spacji
        ///     - If w przeciągu tych samych 3 znaków brak spacji, zkończ bezzwłocznie po 200 znakach 
        ///         
        ///     If kropka/przecinek + spacja -> zakończ pierwszą sekcje za kropką - drugą rozpocznij bez spacji jeśli taka/takie były za kropką
        ///     **gdy wielokropek, po nim
        ///     If kropka/przecinek -> analogicznie
        ///     If spacja -> zakończ bez spacji; drugą rozpocznij bez spacji
        ///     If brak spacji -> perwij po 70 znaku; drugą rozpocznij po po;
        ///     
        /// Kolejne sekcje analogiczne podziały jak dla pierwszego
        /// </summary>
        [Fact]
        public void IsDivideCorrectNorlamMode() // When dot and space occurs
        {
            // Arrange
            DALLibrary.DomainModel.Book book = new DALLibrary.DomainModel.Book()
            {
                ID = 1,
                Title = "TitleTest",
                Author = "AuthorTest",
                Content = "In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters.     Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless. Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless. He’d grown up, I learned, in an affluent suburb of Washington, D.C., where he’d excelled academically and had been an elite athlete. Immediately after graduating, with honors, from Emory University in the summer of 1990, McCandless dropped out of sight... He changed his name, gave the entire balance of a twenty-four-thousand-dollar savings account to charity, abandoned his car and most of his possessions, burned all the cash in his wallet. And then he invented a new life for himself, taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience. "
            };

            // Act
            var bookContent = book.Content;

            var divideStartFrom = 200;
            var divideEndAfterNext = 200;

            var testingPart01 = "";
            var testingPart02 = "";
            var testingPart03 = "";
            var testingPart04 = "";
            var testingPart05 = "";

            // Assert
            Assert.Equal("In April 1992, a young man from a well-to-do East Coast family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later his decomposed body was found by a party of moose hunters.", testingPart01);

            Assert.Equal("Shortly after the discovery of the corpse, I was asked by the editor of Outside magazine to report on the puzzling circumstances of the boy’s death. His name turned out to be Christopher Johnson McCandless.", testingPart02); // Removing additional spaces in division

            Assert.Equal("He’d grown up, I learned, in an affluent suburb of Washington, D.C., where he’d excelled academically and had been an elite athlete. Immediately after graduating, with honors, from Emory University in the summer of 1990, McCandless dropped out of sight...", testingPart03); // Zignorowanie powielonych spacji + Brak spacji za kropką -> przerzucenie się na samą kropkę

            Assert.Equal("He changed his name, gave the entire balance of a twenty-four-thousand-dollar savings account to charity, abandoned his car and most of his possessions, burned all the cash in his wallet. And then he invented a new life for himself, taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience.", testingPart04); // Brak kropki -> przerzucenie się na przecinek+spacja

            Assert.Equal("taking up residence at the ragged margin of our society, wandering across North America in search of raw, transcendent experience, His family had no idea where he was or what had become of him until his remains turned up in Alaska,", testingPart05); // Brak kropki, przecinka+spacja => użycie przecinka bez spacji

            //toDO

            // Brak kropek, przecinkow => użycie spacji

            // Brak czegokolwiek => podzial po 200 znaku
        }

        [Fact]
        public void IsDivideCorrectNoSpaceAfterDots() // When dot occurs without spaces
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void IsDivideCorrectNoDots() // No dots => comma + space
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void IsDivideCorrectNoSpaceAfterComma() // No comma + space => comma
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void IsDivideCorrectNoComma() // No comma => space
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void IsDivideCorrectNoSpace() // No space => hard divide
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
