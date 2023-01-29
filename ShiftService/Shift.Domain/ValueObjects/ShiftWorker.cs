using SharedKernel.Primitives;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ShiftService.Domain.ValueObjects
{
    public class ShiftWorker : ValueObject
    {
        
        public Guid EmployeeId { get; private init; }
        
        public Guid JobTitleId { get; private init; }

        public ShiftTime ShiftTime { get; private init; }

        // for Ef
        private ShiftWorker() {}

        public ShiftWorker(Guid employeeId, Guid jobTitleId, ShiftTime shiftTime)
        {
            EmployeeId = employeeId;
            JobTitleId = jobTitleId;
            ShiftTime = shiftTime;
        }

        public static explicit operator ShiftWorker(string shiftWorker)
        {
            ShiftWorker? result = JsonSerializer.Deserialize<ShiftWorker>(shiftWorker);
            
            return result;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }


        public override IEnumerable<object> GetAtomicValues()
        {
            yield return EmployeeId;
            yield return JobTitleId;
            yield return ShiftTime;
        }
    }
}
