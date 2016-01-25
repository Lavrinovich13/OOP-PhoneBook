using DAL.Repositories.AbstractClasses;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PeopleRepository : ModelRepository<Person>
    {
        public PeopleRepository(PhoneBookEntities context)
            : base(context)
        { }

        public override void Remove(Person item)
        {
            _context.PhoneNumbers.RemoveRange(item.PhoneNumbers);
            base.Remove(item);
        }

        public override void Update(Person item)
        {
            item.PhoneNumbers = null;
            base.Update(item);
        }
    }
}
