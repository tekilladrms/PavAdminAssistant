using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Tests.DomainTests.ValueObjectsTests;

public class NameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("")]
    public void CreateNameWithNullOrWhiteSpaceParameterThrowsException(string value)
    {
        Assert.Throws<ArgumentNullDomainException>(() => Name.Create(value));
    }

    [Theory]
    [InlineData("123")]
    [InlineData("%")]
    [InlineData("%%%")]
    [InlineData("jsdhalfjkasldkjfhlaskjdfhlaskjdfhlkajsdhflkjasdhflkjasdhf")]
    public void CreateNameWithIncorrectParameterThrowsException(string value)
    {
        Assert.Throws<ArgumentIsNotValidDomainException<string>>(() => Name.Create(value));
    }

    [Theory]
    [InlineData("Alex")]
    [InlineData("Fedurin Оглы")]
    public void CreateNameWithCorrectParameterReturnsInstance(string value)
    {
        Assert.NotNull(Name.Create(value));
    }
}