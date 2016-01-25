using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T FindById(int id);
        List<T> GetAll();
    }
}
