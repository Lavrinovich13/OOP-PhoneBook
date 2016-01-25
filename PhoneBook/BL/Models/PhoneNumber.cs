using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class PhoneNumber
    {
        public int Id { get; protected set; }
        public int PersonId { get; protected set; }
        public string Number { get; set; }
        public string Description { get; set; }
        
        public PhoneNumber(string number, string description = null)
        {
            this.Number = number;
            this.Description = description;
        }

        public string FullInfo
        {
            get
            {
                return String.Format("{0} {1}", Number, Description);
            }
        }

        public void SetPerson(int p)
        {
            PersonId = p;
        }
    }
}
