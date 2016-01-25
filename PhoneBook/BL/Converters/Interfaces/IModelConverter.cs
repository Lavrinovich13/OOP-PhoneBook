using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converters.Interfaces
{
    public interface IModelConverter<T,K>
    {
        T Convert(K item);
        K Convert(T item);
    }
}
