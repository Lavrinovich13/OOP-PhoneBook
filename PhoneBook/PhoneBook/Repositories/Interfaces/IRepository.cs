using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IList<T> Items { get; }

        void Add(T newPerson);
        void Remove(int id);
        void Edit(T editPerson);

        void SaveChanges();
    }
}
