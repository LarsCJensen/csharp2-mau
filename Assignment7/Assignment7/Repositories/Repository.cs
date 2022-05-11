using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class Repository : IRepository<object>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<object> Get()
        {
            throw new NotImplementedException();
        }

        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public object Save(object entity)
        {
            throw new NotImplementedException();
        }
    }
}