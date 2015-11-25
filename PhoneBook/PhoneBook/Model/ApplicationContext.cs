using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("PhoneBook"){}
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
