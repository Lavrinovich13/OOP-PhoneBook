namespace PhoneBook
{
    using PhoneBook.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext()
            : base("name=PhoneBook")
        {
        }
    
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}