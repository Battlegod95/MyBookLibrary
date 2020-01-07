using Monti.MyBookLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monti.MyBookLibrary.Data
{
    public interface IGenresRepository
        : IRepository<Genre, byte>
    {
        IEnumerable<Genre> GetBookByGenres(byte genreId);
    }
       
}
