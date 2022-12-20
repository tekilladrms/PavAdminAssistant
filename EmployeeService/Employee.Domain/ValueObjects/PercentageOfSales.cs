
using EmployeeService.Domain.Exceptions;
using SharedKernel.Interfaces;
using SharedKernel.Primitives;
using System.Collections.Generic;

namespace EmployeeService.Domain.ValueObjects;
public class PercentageOfSales : ValueObject, IValidable<decimal>
{
    public decimal Value { get; private set; } = default;

    //for EF
    private PercentageOfSales() { }
    private PercentageOfSales(decimal value) => Value = value;


    public static PercentageOfSales Create(decimal value)
    {
        if (!IsValid(value)) throw new ValueIsLessThanZeroDomainException(value);
        return new PercentageOfSales(value);
    }

    public static bool IsValid(decimal value)
    {
        if (value < 0) return false;

        return true;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}