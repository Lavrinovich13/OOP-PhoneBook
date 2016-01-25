using DAL.Repositories.Interfaces;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork.Interfaces
{
    public interface IPhonesUnitOfWork : IDisposable
    {
        IRepository<Person> PeopleRepository { get; }
        IRepository<PhoneNumber> PhoneNumbersRepository { get; }
        void SaveChanges();
    }
}
