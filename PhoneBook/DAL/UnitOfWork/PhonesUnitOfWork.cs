using DAL.Repositories;
using DAL.Repositories.AbstractClasses;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork.Interfaces;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class PhonesUnitOfWork: IDisposable, IPhonesUnitOfWork
    {
        protected PhoneBookEntities _context;

        protected IRepository<Person> _peopleRepository;
        protected IRepository<PhoneNumber> _phoneNumbersRepository;

        public IRepository<Person> PeopleRepository 
        {
            get 
            {
                return _peopleRepository == null ? 
                    new PeopleRepository(_context) : _peopleRepository;
            }
        }

        public IRepository<PhoneNumber> PhoneNumbersRepository
        {
            get
            {
                return _phoneNumbersRepository == null ? 
                    new PhoneNumbersRepository(_context) : _phoneNumbersRepository;
            }
        }

        public PhonesUnitOfWork()
        {
            _context = new PhoneBookEntities();

            _peopleRepository = new PeopleRepository(_context);
            _phoneNumbersRepository = new PhoneNumbersRepository(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
