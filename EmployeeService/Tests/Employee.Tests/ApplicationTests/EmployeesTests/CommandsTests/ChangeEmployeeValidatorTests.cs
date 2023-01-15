using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.ChangeEmployee;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class ChangeEmployeeValidatorTests
{
    private readonly ChangeEmployeeValidator _validator;
    public ChangeEmployeeValidatorTests()
    {
        _validator = new ChangeEmployeeValidator();
    }
    [Fact]
    public void Validator_ShouldReturnTrue_WhenValuesAreCorrect()
    {
        //Arrange
        var command = new ChangeEmployeeCommand(
            new EmployeeDto
            {
                Id = Guid.NewGuid(),
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "89561472312",
                BirthDate = "25.10.1988",
                JobTitleId = Guid.NewGuid()
            });

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);

    }

    [Fact]
    public void Validator_ShouldReturnFalse_WhenGuidIsEmpty()
    {
        //Arrange
        var command = new ChangeEmployeeCommand(
            new EmployeeDto
            {
                Id = Guid.Empty,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "89561472312",
                BirthDate = "25.10.1988",
                JobTitleId = Guid.NewGuid()
            });

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validator_ShouldReturnFalse_WhenFirstNameIsIncorrect()
    {
        //Arrange
        var command = new ChangeEmployeeCommand(
            new EmployeeDto
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "Test",
                PhoneNumber = "89561472312",
                BirthDate = "25.10.1988",
                JobTitleId = Guid.NewGuid()
            });

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

    }

    [Fact]
    public void Validator_ShouldReturnFalse_WhenLastNameIsIncorrect()
    {
        //Arrange
        var command = new ChangeEmployeeCommand(
            new EmployeeDto
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "",
                PhoneNumber = "89561472312",
                BirthDate = "25.10.1988",
                JobTitleId = Guid.NewGuid()
            });

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

    }
    [Fact]
    public void Validator_ShouldReturnFalse_WhenPhoneNumberIsIncorrect()
    {
        //Arrange
        var command = new ChangeEmployeeCommand(
            new EmployeeDto
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                BirthDate = "25.10.1988",
                JobTitleId = Guid.NewGuid()
            });

        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

    }
}
