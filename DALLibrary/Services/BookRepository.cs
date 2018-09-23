using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using DALLibrary.DomainModel;
using Dapper;

namespace DALLibrary.Services
{
    /// <summary>
    /// Using SQLite DB and Dapper ORM; More about the Dapper(king ): http://dapper-tutorial.net 
    /// Entity Framework can be used too but its slower: https://docs.microsoft.com/pl-pl/ef/core/get-started/netcore/new-db-sqlite
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = "Data Source=C:/TypingBook/SQLiteDB.db;Version=3";

        #region logic on db    
        public IQueryable<Book> EditContent()
        {
            //ToDo (just example)
            return null;
        }

        public IQueryable<Book> CreateNewBook()
        {
            return null;
        }

        public void Save(IQueryable<Book> booksQuery)
        {
            //ToDo - save all;
        }
        #endregion


        #region get from db
        public IEnumerable<Book> Get()
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var output = cnn.Query<Book>("select * from Book", new DynamicParameters());
                return output;
            }
        }

        public Book Get(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var output = cnn.QuerySingle<Book>($"select * from Book where ID = {id}", new DynamicParameters());
                return output;
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            { 
                var output = await cnn.QueryFirstAsync<Book>($"select * from Book where ID = {id}", new DynamicParameters());
                return output;
            }
        }
        #endregion
    }
}