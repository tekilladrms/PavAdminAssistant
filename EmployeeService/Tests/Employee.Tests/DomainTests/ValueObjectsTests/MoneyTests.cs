using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Tests.DomainTests.ValueObjectsTests;

public class MoneyTests
{
    [Theory]
    [InlineData(0, Currency.RUB)]
    [InlineData(-10, Currency.USD)]
    public void CreateMoneyWithCorrectParametersReturnsInstance(decimal amount, Currency currency)
    {
        Assert.NotNull(Money.Create(amount, currency));
    }
}