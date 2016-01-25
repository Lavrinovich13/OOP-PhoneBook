using AutoMapper;
using BL.Converters.Interfaces;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converters
{
    class PersonModelConverter : IModelConverter<EntityModels.Person, BL.Models.Person>
    {
        public PersonModelConverter()
        {
            Mapper.CreateMap<EntityModels.Person, Person>()
                .ForMember(s => s.PhoneNumbers, c => c.MapFrom(m => m.PhoneNumbers));

            Mapper.CreateMap<Person, EntityModels.Person>();

            Mapper.CreateMap<EntityModels.PhoneNumber, PhoneNumber>();
            Mapper.CreateMap<PhoneNumber, EntityModels.PhoneNumber>();
        }

        public EntityModels.Person Convert(Person item)
        {
            return Mapper.Map<Person, EntityModels.Person>(item);
        }

        public Person Convert(EntityModels.Person item)
        {
            return Mapper.Map<EntityModels.Person, Person>(item);
        }
    }
}
