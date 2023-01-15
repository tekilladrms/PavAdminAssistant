using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Tests.DomainTests.ValueObjectsTests;

public class SalaryTests
{
    [Theory]
    [InlineData(-1, Currency.RUB,SalaryType.PerMonth)]
    public void CreateSalaryWithIncorrectValueParameterThrowsException(decimal value, Currency currency, SalaryType salaryType)
    {
        Assert.Throws<ArgumentIsNotValidDomainException<Salary>>(() => Salary.Create(Money.Create(value, currency), salaryType));
    }

    [Theory]
    [InlineData(120, Currency.RUB,SalaryType.PerMonth)]
    public void CreateSalaryWithCorrectParametersReturnsInstance(decimal value, Currency currency, SalaryType salaryType)
    {
        Assert.NotNull(() => Salary.Create(Money.Create(value, currency), salaryType));
    }
}