using BL.Models;
using BL.PhoneBookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDService service = new CRUDService();
            var persons = service.GetAllPeople();
            var person = persons.ElementAt(0);

            person.FirstName = "Алена";
            person.PhoneNumbers.ElementAt(0).Number = "some";

            service.UpdatePerson(person);
        }
    }
}
