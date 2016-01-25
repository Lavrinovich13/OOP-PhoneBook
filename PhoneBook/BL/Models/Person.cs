using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Person
    {
        protected List<PhoneNumber> _PhoneNumbers;

        public int Id { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string ImagePath { get; set; }

        public List<PhoneNumber> PhoneNumbers { 
            get
            { 
                return _PhoneNumbers.AsEnumerable().ToList(); 
            }
            protected set 
            { 
                _PhoneNumbers = value; 
            } 
        }

        public Person(string firstName, string lastName, string patronymic, string imagePath)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patronymic = patronymic;
            this.ImagePath = imagePath;

            PhoneNumbers = new List<PhoneNumber>();
        }

        public string FullName 
        { 
            get 
            { 
                return String.Format("{0} {1} {2}", LastName, FirstName, Patronymic); 
            }
        }

        public void AddPhones(List<PhoneNumber> numbers)
        {
            if(numbers != null)
            {
                _PhoneNumbers.AddRange(numbers);
            }
        }
    }
}
