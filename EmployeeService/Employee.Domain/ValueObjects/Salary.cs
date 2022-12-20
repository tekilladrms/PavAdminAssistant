
using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using SharedKernel.Interfaces;
using SharedKernel.Primitives;
using System.Collections.Generic;

namespace EmployeeService.Domain.ValueObjects;
public class Salary : ValueObject, IValidable<decimal>
{
    public Money Money { get; private set; } = Money.Create(0, Currency.RUB);
    public SalaryType SalaryType { get; private set; } = SalaryType.PerHour;

    //for EF
    private Salary() { }

    private Salary(Money money, SalaryType salaryType) 
    {
        Money = money;
        SalaryType = salaryType;
    }


    public static Salary Create(Money money, SalaryType salaryType)
    {
        if (!IsValid(money.Amount)) throw new IncorrectParameterDomainException(nameof(money));
        return new Salary(money, salaryType);
    }

    public SalaryType GetSalaryType()
    {
        return SalaryType;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Money;
        yield return SalaryType;
    }


    public static bool IsValid(decimal value)
    {
        if(value < 0) return false;

        return true;
    }
}