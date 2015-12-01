using PhoneBook;
using PhoneBook.DAL.AbstractRepository;
using PhoneBook.DAL.Interfaces;
using PhoneBook.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PeopleRepository : DataRepository<Person>
    {
        public PeopleRepository(PhoneBookDb context)
            : base(context)
        { }
    }
}
