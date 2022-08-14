using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.interfaces
{
    public interface IRepository<T>
    {
        T Get(long id);

        void Delete(long id);

        void Add(T entity);

        void Update(T entity);

        IQueryable<T> GetAll();
    }
}
