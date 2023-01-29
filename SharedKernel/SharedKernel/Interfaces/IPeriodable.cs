using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Interfaces
{
    public interface IPeriodable
    {
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
}
