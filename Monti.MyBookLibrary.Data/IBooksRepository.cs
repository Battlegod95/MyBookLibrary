using Monti.MyBookLibrary.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monti.MyBookLibrary.Data
{
    public interface IBooksRepository
        : IRepository<Book>
    {
        //Book Get(int id);

        //IEnumerable<Book> GetAll();

        //void Insert(Book model);

        //void Update(Book model);

        //void Delete(Book id);

        IEnumerable<Book> GetByGenres(byte genresId);
    }
}
