using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System.Collections.Generic;

namespace EmployeeService.Domain.ValueObjects;

public class Money : ValueObject
{
    public decimal Amount { get; private set; } = decimal.Zero;
    public Currency Currency { get; private set; } = Currency.RUB;


    //private empty ctor for EF
    private Money()
    {

    }
    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, Currency currency)
    {
        return new Money(amount, currency);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }
}