using BLLLibrary.ViewModels;
using DALLibrary.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLLibrary.Helpers
{
    public class BookHelper
    {
        public List<string> DivideBook(string bookContent) // Rename to Split ?
        {
            var minLenght = 200;
            //var maxLenght = 400;

            var result = Enumerable.Range(0, bookContent.Length / minLenght).Select(i => bookContent.Substring(i * minLenght, minLenght)).ToList();

            return result;
        }
    }
}
