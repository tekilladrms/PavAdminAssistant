using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Tests.DomainTests.ValueObjectsTests;

public class PhoneNumberTests
{
    [Theory]
    [InlineData(null)]
    public void CreatePhoneNumberWithNullParameterThrowsException(string value)
    {
        Assert.Throws<ArgumentNullDomainException>(() => PhoneNumber.Create(value));
    }

    [Theory]
    [InlineData("      ")]
    [InlineData("-79659001995")]
    [InlineData("-796-590-01-995")]
    public void CreatePhoneNumberWithIncorrectParameterThrowsException(string value)
    {
        Assert.Throws<ArgumentIsNotValidDomainException<PhoneNumber>>(() => PhoneNumber.Create(value));
    }
}