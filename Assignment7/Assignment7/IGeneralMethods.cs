using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    // Add, Edit, Delete, Search??
    // TODO IEntity??
    public interface IGeneralMethods<T> where T:class, new()
    {
        IQueryable<T> Get();
        T Get(int id);
        T Save(ThreadStaticAttribute entity);
        void Delete();
        
    }
    public class Repository<T> : IRepository<T> where T : class, new()
    {

    }

}