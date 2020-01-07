using Monti.MyBookLibrary.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monti.MyBookLibrary.Data
{
    
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class
    {

    }

    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        TEntity Get(TPrimaryKey id);

        IEnumerable<TEntity> GetAll();

        void Insert(TEntity model);

        void Update(TEntity model);

        void Delete(TPrimaryKey id);
    }
}
