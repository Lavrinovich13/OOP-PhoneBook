using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneBookContext context = new PhoneBookContext())
            {
                context.Persons.Add(new Model.Person() { FirstName = "Алена", LastName = "Буткевич", Patronymic = "Антоновна", Description = "Подруга" });
                context.SaveChanges();
            }
        }
    }
}
