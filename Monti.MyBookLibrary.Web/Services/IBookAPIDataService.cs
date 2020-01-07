using Monti.MyBookLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monti.MyBookLibrary.Web.Services
{
    public interface IBookApiDataService
    {
        Task<Doc[]> GetBooksApi(string title);
        Task<Details> GetBookDetails(string isbn);
    }
}
