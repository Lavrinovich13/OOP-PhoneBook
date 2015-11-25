using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class RepositoryModelPhoneNumber : IComparable<RepositoryModelPhoneNumber>
    {
        public int Id { get; protected set; }
        public int PersonId { get; protected set; }
        public string Number { get; protected set; }
        public string Description { get; protected set; }

        public RepositoryModelPhoneNumber(int id, int personId, string number, string description)
        {
            this.Id = id;
            this.PersonId = personId;
            this.Number = number;
            this.Description = description;
        }

        public RepositoryModelPhoneNumber(PhoneNumber phoneNumber)
        {
            this.Id = phoneNumber.Id;
            this.PersonId = phoneNumber.PersonId;
            this.Number = phoneNumber.Number;
            this.Description = phoneNumber.Description;
        }

        public PhoneNumber ToPhoneNumber()
        {
            return new PhoneNumber() 
              { Id = this.Id, 
                Number = this.Number, 
                PersonId = this.PersonId, 
                Description = this.Description };
        }

        public string CreateFullNumber()
        {
            return String.Format("{0} {1}", this.Number, this.Description);
        }

        public int CompareTo(RepositoryModelPhoneNumber other)
        {
            return String.Compare(CreateFullNumber(), other.CreateFullNumber(), true);
        }
    }
}
