﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validators.Interfaces
{
    public interface IValidator<T>
        where T : class
    {
        bool IsValid(T item);
    }
}
