using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftService.Domain.Exceptions
{
    public class ArgumentIsNullDomainException : DomainException
    {
        public ArgumentIsNullDomainException(string message) : base(message)
        {
        }
    }
}
