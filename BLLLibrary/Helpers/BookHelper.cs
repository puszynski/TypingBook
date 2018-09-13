using BLLLibrary.ViewModels;
using DALLibrary.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLLibrary.Helpers
{
    public class BookHelper
    {
        public BookViewModel DivideBook(Book book)
        {
            var dividedContent = new List<string>();
            //ToDo book.Content

            var result = new BookViewModel() {
                ID = book.ID,
                TitleAndAuthors = book.Title + " " + book.Author,
                DividedContent = dividedContent
            };

            return result;
        }
    }
}
