using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> Get();
        IQueryable<T> GetAll();
        T Get(int id);
        T Save(T entity);
        void Delete(int id);
    }
}