
using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System.Collections.Generic;

namespace EmployeeService.Domain.ValueObjects;
public class PercentageOfSales : ValueObject
{
    public decimal Value { get; private set; } = default;

    //for EF
    private PercentageOfSales() { }
    private PercentageOfSales(decimal value) => Value = value;


    public static PercentageOfSales Create(decimal value)
    {
        if (value < 0) throw new ValueIsLessThanZeroDomainException(value);
        return new PercentageOfSales(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}