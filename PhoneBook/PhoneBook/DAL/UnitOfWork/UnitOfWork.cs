using DAL.Repositories;
using PhoneBook.DAL.AbstractRepository;
using PhoneBook.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repositories.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        protected PhoneBookDb _context;

        protected DataRepository<Person> _peopleRepository;
        protected DataRepository<PhoneNumber> _phoneNumbersRepository;

        public DataRepository<Person> PeopleRepository 
        {
            get 
            {
                return _peopleRepository == null ? new PeopleRepository(_context) : _peopleRepository;
            }
        }

        public DataRepository<PhoneNumber> PhoneNumbersRepository
        {
            get
            {
                return _phoneNumbersRepository == null ? new PhoneNumbersRepository(_context) : _phoneNumbersRepository;
            }
        }

        public UnitOfWork()
        {
            _context = new PhoneBookDb();

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
            GC.SuppressFinalize(this);
        }
    }
}
