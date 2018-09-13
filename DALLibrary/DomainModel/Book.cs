using DALLibrary.Services;

namespace DALLibrary.DomainModel
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public string TitleAndAuthor()
        {
            return $"{Title} {Author}";
        }

        //TODO public <Author> Authors { get; set; }
    }
}
