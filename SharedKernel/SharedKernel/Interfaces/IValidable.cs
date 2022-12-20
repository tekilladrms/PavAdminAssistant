using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Interfaces
{
    public interface IValidable<TValue>
    {
        public static abstract bool IsValid(TValue value);
    }
}
