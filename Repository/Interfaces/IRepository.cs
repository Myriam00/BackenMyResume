using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(params object[] keyValues);
        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);
    }
}


