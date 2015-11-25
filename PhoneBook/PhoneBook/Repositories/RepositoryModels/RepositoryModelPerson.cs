using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class RepositoryModelPerson : IComparable<RepositoryModelPerson>
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Patronymic { get; protected set; }
        public string Description { get; protected set; }

        public RepositoryModelPerson(int id, string firstName, string lastName, string patronymic, string description)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.Description = description;
        }

        public RepositoryModelPerson(Person person)
        {
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Patronymic = person.Patronymic;
            this.Description = person.Description;
        }

        public string CreateFullName()
        {
            return String.Format("{0} {1} {2} {3}", this.FirstName, this.LastName, this.Patronymic, this.Description);
        }

        public int CompareTo(RepositoryModelPerson other)
        {
            return String.Compare(CreateFullName(), other.CreateFullName(), true);
        }

        public Person ToPerson()
        {
            return new Person() 
               { Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Patronymic = this.Patronymic,
                Description = this.Description };
        }
    }
}
