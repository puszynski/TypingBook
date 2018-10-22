using System.Collections.Generic;

namespace BLLLibrary.Helpers
{
    public class BookHelper
    {
        #region divideBook
        /// <summary>
        /// Aplikacja zakłada że Book.Content przechowuje prawidłowo sforatowany string, gdzie zdania są rozdzielone za pomocą ". " oraz nie wsystępują powielone spacje. 
        /// </summary>
        public List<string> DivideBook(string bookContent)
        { 
            const int minAndMaxLenghtOfBothParts = 200;
            var rest = bookContent; // Use string builder?      
            //rest = "Hi! :) TypingBook is simple but smarth app that will rise yours quick and accuracy typing on keyboard and english words knowleadge - rewritng is Key here. Those skills will help you on many areas. But in the same time, you can relax by typing your favorite books or use one of recomended. Skill up, learn and take a fun! Switch to Light Layout if you prefer. Use minimise option to size TypingWindow to minimum, so you can e.g. watch movie in the same time. By default we will use cookies to save your actuall progress on your computer. You have access to our library of public books. If you need more - add your own books or load your notes to rewrite it(its briliant excersize) or get more advance statistisc - please LogIN so we can store your data in our Data Base. Now please enjoy the journey with default book - IN TO THE WILD by Jon Krakauer.";
            var firstPart = "";
            var secondPart = "";
            var bookPages = new List<string>();
            var IsEnd = false;

            while (rest != "")
            {
                if (IsLastPart(rest))
                    firstPart = rest.Substring(0, minAndMaxLenghtOfBothParts);
                
                if(!IsEnd)
                    rest = rest.Replace(firstPart, "");                  

                if (IsLastPart(rest, true))
                {
                    secondPart = rest.Substring(0, rest.IndexOf(". ") + 1);

                    if (secondPart.Length >= minAndMaxLenghtOfBothParts)
                        secondPart = secondPartAlternatives(rest);
                }
                
                if(!IsEnd)
                {
                    rest = rest.Replace(secondPart, "");
                    rest = removeStartSpaces(rest);
                }

                bookPages.Add(firstPart + secondPart);
                firstPart = "";
                secondPart = "";                                    
            }
            return bookPages;


           
            bool IsLastPart(string input, bool IsSecondPart = false)
            {
                var result = input.Length >= minAndMaxLenghtOfBothParts ? true : false;

                if (result == false && IsEnd == false)
                {
                    IsEnd = true;

                    if (IsSecondPart)
                        secondPart = rest;  
                    else
                        firstPart = rest;

                    rest = "";
                }
                return result;
            }


            string secondPartAlternatives(string input)
            {
                var  result = input.Substring(0, rest.IndexOf(", ") + 1);
                if (result.Length >= minAndMaxLenghtOfBothParts)
                    result = input.Substring(0, rest.IndexOf(" ") + 1);
                return result;
            }

            string removeStartSpaces(string input)
            {
                var result = input;
                while (result.Substring(0, 1) == " ")
                    result = input.Substring(1, result.Length-1);

                return result;
            }
        }
        #endregion

        #region NewBookContentValidator
        #endregion

    }
}
