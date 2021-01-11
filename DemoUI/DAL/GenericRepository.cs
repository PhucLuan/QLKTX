using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUI.DAL
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context = null;
        private DbSet<T> dbset = null;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void Edit(T entity)
        {
            context.SaveChanges();
        }

        public T Get(Func<T, bool> predicate)
        {
            return dbset.FirstOrDefault(predicate);
        }

        public List<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return dbset.Where(predicate).ToList();
            }
            else
                return dbset.ToList();
        }
    }
}
