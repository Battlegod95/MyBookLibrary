using Monti.MyBookLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monti.MyBookLibrary.Data
{
    public interface IBookReadHistoryRespository
        : IRepository<BookReadHistory>
    {
        /*
        Metodo vecchio
        BookReadHistory Get(int id);
        IEnumerable<BookReadHistory> GetAll();
        void Insert(BookReadHistory model);
        void Update(BookReadHistory model);
        void Delete(int id);
        */

        IEnumerable<BookReadHistory> GetByBook(int bookId);
    }
}
