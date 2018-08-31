using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
        private readonly string _connectionString = "Data Source=C:/Users/puszy/Documents/PROJECTS/TypingBook 0.2/TypingBook/SQLiteDB.db;Version=3";


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

    }
}