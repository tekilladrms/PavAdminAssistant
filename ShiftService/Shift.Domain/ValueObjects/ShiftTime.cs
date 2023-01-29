using SharedKernel.Primitives;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ShiftService.Domain.ValueObjects
{
    public class ShiftTime : ValueObject
    {
        public DateTime Start { get; private init; }

        
        public DateTime End { get; private init; }

        // for EF
        private ShiftTime() {}


        public ShiftTime(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return End;
        }
    }
}
