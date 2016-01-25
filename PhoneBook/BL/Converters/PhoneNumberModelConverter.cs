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
    class PhoneNumberModelConverter: IModelConverter<EntityModels.PhoneNumber, BL.Models.PhoneNumber>
    {
        public PhoneNumberModelConverter()
        {
            Mapper.CreateMap<EntityModels.PhoneNumber, PhoneNumber>();
            Mapper.CreateMap<PhoneNumber, EntityModels.PhoneNumber>();
        }

        public EntityModels.PhoneNumber Convert(PhoneNumber item)
        {
            return Mapper.Map<PhoneNumber, EntityModels.PhoneNumber>(item);
        }

        public PhoneNumber Convert(EntityModels.PhoneNumber item)
        {
            return Mapper.Map<EntityModels.PhoneNumber, PhoneNumber>(item);
        }
    }
}
