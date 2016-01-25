using AutoMapper;
using BL.Converters.Interfaces;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.ViewModels.Converters
{
    public class PhoneNumberConverter : IModelConverter<PhoneNumber, PhoneNumberGridItem>
    {
        public PhoneNumberConverter()
        {
            Mapper.CreateMap<PhoneNumber, PhoneNumberGridItem>();
            Mapper.CreateMap<PhoneNumberGridItem, PhoneNumber>();
        }

        public PhoneNumber Convert(PhoneNumberGridItem item)
        {
            return Mapper.Map<PhoneNumberGridItem, PhoneNumber>(item);
        }

        public PhoneNumberGridItem Convert(PhoneNumber item)
        {
            return Mapper.Map<PhoneNumber, PhoneNumberGridItem>(item);
        }
    }
}
