using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Monti.MyBookLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Monti.MyBookLibrary.Data.Repositories
{
   
    public class GenresRepository : IGenresRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

    public GenresRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

        public void Delete(byte id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new Genre() { Id = id });
            }
        }

        public Genre Get(byte id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Genre>(id);
            }
        }

        public IEnumerable<Genre> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //utilizzo di dapper.contrib
                return connection.GetAll<Genre>();
            }
        }

        public IEnumerable<Genre> GetBookByGenres(byte genreId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //utilizzo di dapper.contrib
                return connection.Query<Genre>(@"
                    SELECT [Id]
                          ,[Description]
                      FROM [dbo].[Genres]
                      WHERE [Id] IN @genreId", new { Book = genreId });
            }
        }

        public void Insert(Genre model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //utilizzo di dapper.contrib
                connection.Insert(model);
            }
        }

        public void Update(Genre model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //utilizzo di dapper.contrib
                connection.Update(model);
            }
        }
    }
}
