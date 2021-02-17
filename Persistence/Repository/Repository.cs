using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Repository.Interfaces;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MyResumeContext Context;

        public Repository(MyResumeContext context)
        {
            Context = context;
        }

        public virtual void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T GetById(params object[] id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            //Context.Entry(entity).State = EntityState.Modified;
        }
    }
}





