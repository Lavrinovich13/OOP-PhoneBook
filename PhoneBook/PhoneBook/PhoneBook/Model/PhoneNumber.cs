using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
    }
}
