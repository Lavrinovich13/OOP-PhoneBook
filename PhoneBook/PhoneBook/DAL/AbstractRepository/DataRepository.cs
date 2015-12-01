using PhoneBook.DAL.Interfaces;
using PhoneBook.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.AbstractRepository
{
    public abstract class DataRepository<T> : IRepository<T>
        where T : class
    {
        protected PhoneBookDb _context;

        public DataRepository(PhoneBookDb context)
        {
            if (context == null)
                throw new NullReferenceException();
            _context = context;
        }

        public void Add(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        public void Remove(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Update(T item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return new List<T>(_context.Set<T>().Where(predicate));
        }
    }
}
