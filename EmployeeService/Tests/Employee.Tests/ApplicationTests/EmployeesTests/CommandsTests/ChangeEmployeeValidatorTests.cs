using EmployeeService.Application.Employees.Commands.UpdateEmployee;
using System;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class ChangeEmployeeValidatorTests
{
    private readonly UpdateEmployeeCommandValidator _validator;
    public ChangeEmployeeValidatorTests()
    {
        _validator = new UpdateEmployeeCommandValidator();
    }
    [Fact]
    public void Validator_ShouldReturnTrue_WhenValuesAreCorrect()
    {
        //Arrange
        var command = new UpdateEmployeeCommand(
            Guid.NewGuid().ToString(),
                "test",
                "test",
                "89561472312",
                "25.10.1988");

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);

    }


    [Fact]
    public void Validator_ShouldReturnFalse_WhenFirstNameIsIncorrect()
    {
        //Arrange
        var command = new UpdateEmployeeCommand(
            Guid.NewGuid().ToString(),
                "",
                "Test",
                "89561472312",
                "25.10.1988");

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

    }

    [Fact]
    public void Validator_ShouldReturnFalse_WhenLastNameIsIncorrect()
    {
        //Arrange
        var command = new UpdateEmployeeCommand(
            Guid.NewGuid().ToString(),
            "Test",
            "",
            "89561472312",
            "25.10.1988");


        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

    }
    [Fact]
    public void Validator_ShouldReturnFalse_WhenPhoneNumberIsIncorrect()
    {
        //Arrange
        var command = new UpdateEmployeeCommand(
            Guid.NewGuid().ToString(),
            "Test",
                "Test",
                "Test",
                "25.10.1988");

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

    }
}
