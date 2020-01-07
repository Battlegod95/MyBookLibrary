using Monti.MyBookLibrary.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dapper.Contrib;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Monti.MyBookLibrary.Data.Repositories
{
    public class BookReadHistoryRepository : IBookReadHistoryRespository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BookReadHistoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new BookReadHistory() { Id = id });
            }
        }

        public BookReadHistory Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<BookReadHistory>(id);
            }
        }

        public IEnumerable<BookReadHistory> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<BookReadHistory>();
            }
        }

        public IEnumerable<BookReadHistory> GetByBook(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<BookReadHistory>(@"
                    SELECT [Id]
                          ,[BookId]
                          ,[ReadStart]
                          ,[ReadEnd]
                          ,[Notes]
                      FROM [dbo].[ReadHistories]", new { Book = bookId });
            }
        }

        public void Insert(BookReadHistory model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }

        public void Update(BookReadHistory model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(model);
            }
        }
    }
}
