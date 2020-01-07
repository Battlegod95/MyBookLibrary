using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Monti.MyBookLibrary.Web.Data.Models;

namespace Monti.MyBookLibrary.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IConfiguration _configuration; //serve per passare le configurazioni per andare a connettersi con il database
        private readonly string _connectionString;

        public BooksRepository(IConfiguration configuration) //basta selezionare la riga sopra fare ctrl punto e implementare il costruttore
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Query<Book>(@"
                    DELETE FROM [dbo].[Books]
                    WHERE Id = @Id",new { Id = id });
            }
        }

        public Book Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {//First or default per la query prende il primo dato che gli arriva e non altro se no fa default e segna null
                return connection.QueryFirstOrDefault<Book>(@"
SELECT [Id]
      ,[Title]
      ,[Author]
      ,[Description]
      ,[CreationDate]
      ,[GenreId]
      ,[PublishedDate]
      ,[IsRead]
      ,[DateLastUpdate]
      ,[ImageUrl]
      ,[Rate]
  FROM [dbo].[Books]
  WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Book>(@"
SELECT [Id]
      ,[Title]
      ,[Author]
      ,[Description]
      ,[CreationDate]
      ,[GenreId]
      ,[PublishedDate]
      ,[IsRead]
      ,[DateLastUpdate]
      ,[ImageUrl]
      ,[Rate]
  FROM [dbo].[Books]");
            }
        }

        public IEnumerable<Book> GetByGenre(byte genreId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Book>(@"
SELECT [Id]
      ,[Title]
      ,[Author]
      ,[Description]
      ,[CreationDate]
      ,[GenreId]
      ,[PublishedDate]
      ,[IsRead]
      ,[DateLastUpdate]
      ,[ImageUrl]
      ,[Rate]
  FROM [dbo].[Books]
  WHERE GenreId = @genreId", new { genreId });
            }
        }

        public IEnumerable<Book> GetByGenres(byte genresId)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Book model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }

        public void Update(Book model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(model);
            }
        }
    }
}
