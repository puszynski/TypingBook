using DALLibrary.DomainModel;
using System.Collections.Generic;

namespace DALLibrary.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get();
        Book Get(int id);
    }
}
