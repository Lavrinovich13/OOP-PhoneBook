using PhoneBook.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PeopleRepository : IRepository<RepositoryModelPerson>
    {
        protected IList<Person> _people;
        protected ApplicationContext _context = new ApplicationContext();

        public PeopleRepository()
        {
            _people = _context.People.ToList();
        }

        public IList<RepositoryModelPerson> Items
        {
            get
            {
                return _people.Select(x => new RepositoryModelPerson(x)).ToList();
            }
        }
        public void Add(RepositoryModelPerson newPerson)
        {
            if (!_people.Select(x => new RepositoryModelPerson(x)).Contains(newPerson))
            {
                var entityPerson = newPerson.ToPerson();

                entityPerson.Id= _people.Count() == 0 ? 1 : _people.Select(x => x.Id).Max() + 1;
                _context.People.Add(entityPerson);
                _people.Add(entityPerson);
            }
        }

        public void Remove(int id)
        {
            var person = _people.SingleOrDefault(x => x.Id == id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
                _people = _context.People.ToList();
            }
        }

        public async void Edit(RepositoryModelPerson editPerson)
        {
            var person = await _context.People.FindAsync(editPerson.Id);

            if (person != null)
            {
                _context.Entry(person).CurrentValues.SetValues(editPerson);
                _context.SaveChanges();
                _people = _context.People.ToList();
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
