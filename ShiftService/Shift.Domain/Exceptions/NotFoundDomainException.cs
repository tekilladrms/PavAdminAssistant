using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftService.Domain.Exceptions
{
    public class NotFoundDomainException : DomainException
    {
        public NotFoundDomainException(string message) : base(message)
        {
        }
    }
}
