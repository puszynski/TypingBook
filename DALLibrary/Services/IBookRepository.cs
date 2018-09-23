using DALLibrary.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DALLibrary.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get();
        Book Get(int id);
        Task<Book> GetAsync(int id);
    }
}
