using BL.Converters;
using BL.Converters.Interfaces;
using BL.Models;
using DAL.UnitOfWork;
using DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.PhoneBookServices
{
    public class PhoneBookSearchService : IDisposable
    {
        protected IPhonesUnitOfWork _PhonesUnitOfWork;
        protected IModelConverter<EntityModels.Person, Person> _PersonConverter;

        public PhoneBookSearchService()
        {
            _PhonesUnitOfWork = new PhonesUnitOfWork();
            _PersonConverter = new PersonModelConverter();
        }

        public List<SuitablePhoneNumber> Search(string text)
        {
            var suitablePhoneNumbers = new List<SuitablePhoneNumber>();

            var people = _PhonesUnitOfWork.PeopleRepository
                .GetAll()
                .Select(x => _PersonConverter.Convert(x))
                .ToList();

            foreach(var person in people)
            {
                foreach(var number in person.PhoneNumbers)
                {
                    var fullInfo = person.FullName + " " + number.FullInfo;
                    if(ContainsAllParts(text.ToLower(), fullInfo.ToLower()))
                    {
                        suitablePhoneNumbers.Add(new SuitablePhoneNumber(person, number));
                    }
                }
            }

            return suitablePhoneNumbers;
        }

        private bool ContainsAllParts(string text, string fullInfo)
        {
            foreach(var part in text.Split(' '))
            {
                if(!fullInfo.Contains(part))
                {
                    return false;
                }
            }
            return true;
        }

        public void Dispose()
        {
            _PhonesUnitOfWork.Dispose();
        }
    }
}
