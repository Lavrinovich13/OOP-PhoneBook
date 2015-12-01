using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Repositories;
using PhoneBook.DAL.Interfaces;
using PhoneBook.DAL.AbstractRepository;
using PhoneBook;
using PhoneBook.EntityModels;

namespace DAL.Repositories
{
    public class PhoneNumbersRepository : DataRepository<PhoneNumber>
    {
        public PhoneNumbersRepository(PhoneBookDb context)
            : base(context)
        { }
    }
}
