using DAL.Repositories.Interfaces;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.AbstractClasses
{
    public abstract class ModelRepository<T> : IRepository<T>
        where T : class
    {
        protected PhoneBookEntities _context;

        public ModelRepository(PhoneBookEntities context)
        {
            if (context == null)
                throw new NullReferenceException();

            _context = context;
        }

        public virtual void Add(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        public virtual void Remove(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public virtual void Update(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual List<T> GetAll()
        {
            return new List<T>(_context.Set<T>().AsNoTracking());
        }

        public virtual T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
