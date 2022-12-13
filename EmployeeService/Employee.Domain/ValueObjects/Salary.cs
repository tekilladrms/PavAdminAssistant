
using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System.Collections.Generic;

namespace EmployeeService.Domain.ValueObjects;
public class Salary : ValueObject
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
        if (money.Amount < 0) throw new ValueIsLessThanZeroDomainException(money.Amount);
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
}