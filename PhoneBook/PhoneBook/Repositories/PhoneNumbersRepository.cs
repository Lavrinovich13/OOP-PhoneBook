using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Repositories;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook
{
    public class PhoneNumbersRepository : IRepository<RepositoryModelPhoneNumber>
    {
        protected IList<PhoneNumber> _phoneNumbers;
        protected ApplicationContext _context = new ApplicationContext();

        public PhoneNumbersRepository()
        {
            _phoneNumbers = _context.PhoneNumbers.ToList();
        }

        public IList<RepositoryModelPhoneNumber> Items
        {
            get
            {
                return _phoneNumbers.Select(x => new RepositoryModelPhoneNumber(x)).ToList();
            }
        }

        public void Add(RepositoryModelPhoneNumber phoneNumber)
        {
            if (!_phoneNumbers.Select(x => new RepositoryModelPhoneNumber(x)).Contains(phoneNumber))
            {
                var entityPhone = phoneNumber.ToPhoneNumber();
                entityPhone.Id = _phoneNumbers.Count() == 0 ? 1 : _phoneNumbers.Select(x => x.Id).Max() + 1;
                _context.PhoneNumbers.Add(entityPhone);
                _phoneNumbers.Add(entityPhone);
            }
        }

        public void Remove(int id)
        {
            var number = _phoneNumbers.SingleOrDefault(x => x.Id == id);
            if (number != null)
            {
                _context.PhoneNumbers.Remove(number);
                _context.SaveChanges();
                _phoneNumbers = _context.PhoneNumbers.ToList();
            }
        }

        public async void Edit(RepositoryModelPhoneNumber editNumber)
        {
            var number = await _context.PhoneNumbers.FindAsync(editNumber.Id);

            if (number != null)
            {
                _context.Entry(number).CurrentValues.SetValues(editNumber);
                _context.SaveChanges();
                _phoneNumbers = _context.PhoneNumbers.ToList();
            }
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
