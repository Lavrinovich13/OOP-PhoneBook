using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class SuitablePhoneNumber
    {
        public Person Person { get; protected set; }
        public PhoneNumber PhoneNumber { get; protected set; }

        public SuitablePhoneNumber(Person person, PhoneNumber phoneNumber)
        {
            this.Person = person;
            this.PhoneNumber = phoneNumber;
        }
    }
}
