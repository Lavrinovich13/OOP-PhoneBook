using BL.Models;
using BL.Converters;
using BL.Converters.Interfaces;
using DAL.UnitOfWork;
using DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Validators.Interfaces;
using BL.Validators;
using BL.Exceptions;


namespace BL.PhoneBookServices
{
    public class PhoneBookCRUDService : IDisposable
    {
        protected IPhonesUnitOfWork _PhonesUnitOfWork;
        protected IModelConverter<EntityModels.Person, Person> _PersonConverter;
        protected IModelConverter<EntityModels.PhoneNumber, PhoneNumber> _PhoneNumberConverter;
        protected IValidator<Person> _PersonValidator;
  
        public PhoneBookCRUDService()
        {
            _PhonesUnitOfWork = new PhonesUnitOfWork();
            _PersonConverter = new PersonModelConverter();
            _PhoneNumberConverter = new PhoneNumberModelConverter();
            _PersonValidator = new PersonNameValidator(_PersonConverter);
        }

        public Person GetPersonById(int id)
        {
            var item = _PhonesUnitOfWork.PeopleRepository.FindById(id);
            if(item != null)
            {
                return _PersonConverter.Convert(item);
            }
            return null;
        }

        public List<Person> GetAllPeople()
        {
            var entityPersons = _PhonesUnitOfWork.PeopleRepository.GetAll();
            return entityPersons.Select(x => _PersonConverter.Convert(x)).ToList();
        }

        public void RemovePersonById(int id)
        {
            var item = _PhonesUnitOfWork.PeopleRepository.FindById(id);
            if(item != null)
            {
                _PhonesUnitOfWork.PeopleRepository.Remove(item);
                _PhonesUnitOfWork.SaveChanges();
            }
        }

        public void AddPerson(Person person)
        {
            if(person != null)
            {
                if (!_PersonValidator.IsValid(person))
                {
                    throw new DuplicatePersonNameException();
                }
                _PhonesUnitOfWork.PeopleRepository.Add(_PersonConverter.Convert(person));
                _PhonesUnitOfWork.SaveChanges();
            }
        }

        public void UpdatePerson(Person person)
        {
            if(person != null)
            {
                if (!_PersonValidator.IsValid(person))
                {
                    throw new DuplicatePersonNameException();
                }
                _PhonesUnitOfWork.PeopleRepository.Update(_PersonConverter.Convert(person));
                _PhonesUnitOfWork.SaveChanges();
            }
        }

        public void AddNumber(PhoneNumber number)
        {
            if (number != null)
            {
                _PhonesUnitOfWork.PhoneNumbersRepository.Add(_PhoneNumberConverter.Convert(number));
                _PhonesUnitOfWork.SaveChanges();
            }
        }

        public void UpdateNumber(PhoneNumber number)
        {
            if(number != null)
            {
                _PhonesUnitOfWork.PhoneNumbersRepository.Update(_PhoneNumberConverter.Convert(number));
                _PhonesUnitOfWork.SaveChanges();
            }
        }

        public void DeleteNumber(PhoneNumber number)
        {
            if (number != null)
            {
                _PhonesUnitOfWork.PhoneNumbersRepository.Remove(_PhoneNumberConverter.Convert(number));
                _PhonesUnitOfWork.SaveChanges();
            }
        }

        public void Dispose()
        {
            _PhonesUnitOfWork.Dispose();
        }
    }
}
