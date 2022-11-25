using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Tests.DomainTests.ValueObjectsTests;

public class PercentageOfSalesTests
{
    [Theory]
    [InlineData(-1)]
    public void CreatePercentageOfSalesWithNegativeParameterThrowsException(decimal value)
    {
        Assert.Throws<ValueIsLessThanZeroDomainException>(() => PercentageOfSales.Create(value));
    }
}