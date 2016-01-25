using BL.Converters;
using BL.Converters.Interfaces;
using BL.Models;
using BL.Validators.Interfaces;
using DAL.Repositories;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validators
{
    public class PersonNameValidator : IValidator<Person>
    {
        protected IModelConverter<EntityModels.Person, Person> _PersonConverter;

        public PersonNameValidator(IModelConverter<EntityModels.Person, Person> converter)
        {
            _PersonConverter = converter;
        }

        public bool IsValid(Person item)
        {
            Person sameNamePerson = null;

            using (var phonesUnitOfWork = new PhonesUnitOfWork())
            {
                sameNamePerson = phonesUnitOfWork
                    .PeopleRepository
                    .GetAll()
                    .Select(x => _PersonConverter.Convert(x))
                    .SingleOrDefault(x => x.FullName == item.FullName && x.Id != item.Id);
            }

            return sameNamePerson == null ? true : false;
        }
    }
}
