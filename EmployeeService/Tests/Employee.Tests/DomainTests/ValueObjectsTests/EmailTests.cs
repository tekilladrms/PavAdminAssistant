using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Tests.DomainTests.ValueObjectsTests;
public class EmailTests
{
    [Theory]
    [InlineData(null)]
    public void CreateEmailWithNullArgumentThrowingException(string email)
    {
        Assert.Throws<ArgumentNullDomainException>(() => Email.Create(email));
    }

    [Theory]
    [InlineData("   ")]
    public void CreateEmailWithEmptyStringArgumentThrowingException(string email)
    {
        Assert.Throws<IncorrectParameterDomainException>(() => Email.Create(email));
    }

    [Theory]
    [InlineData("sdjfhksadjfhksadhf.com")]
    public void CreateEmailWithIncorrectStringArgumentThrowingException(string email)
    {
        Assert.Throws<IncorrectParameterDomainException>(() => Email.Create(email));
    }

    [Theory]
    [InlineData("dslfd@gmail.com")]
    public void CreateEmailWithCorrectArgumentReturnsInstance(string email)
    {
        Assert.NotNull(Email.Create(email));
    }
}