using System;
using System.Collections.Generic;
using System.Text;

namespace BLLLibrary.ViewModels
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string TitleAndAuthors { get; set; }
        public List<string> DividedContent { get; set; }
    }
}
