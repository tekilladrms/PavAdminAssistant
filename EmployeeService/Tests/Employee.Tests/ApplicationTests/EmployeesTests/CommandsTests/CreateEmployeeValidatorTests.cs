

using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using System;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class CreateEmployeeValidatorTests
{
    private readonly CreateEmployeeCommandValidator _validator;
    public CreateEmployeeValidatorTests()
    {
        _validator = new CreateEmployeeCommandValidator();
    }
    [Fact]
    public void Validator_ShouldReturnTrue_WhenValuesAreCorrect()
    {
        ////Arrange
        //CreateEmployeeCommand command = new CreateEmployeeCommand(
        //    new EmployeeDto
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Test",
        //        LastName = "Test",
        //        PhoneNumber = "89561472312",
        //        BirthDate = "25.10.1988",
        //        JobTitleId = Guid.NewGuid()
        //    });

        ////Act
        //var result = _validator.Validate(command);

        ////Assert
        //Assert.True(result.IsValid);

    }

    [Fact]
    public void Validator_ShouldReturnFalse_WhenFirstNameIsIncorrect()
    {
        ////Arrange
        //CreateEmployeeCommand command = new CreateEmployeeCommand(
        //    new EmployeeDto
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "",
        //        LastName = "Test",
        //        PhoneNumber = "89561472312",
        //        BirthDate = "25.10.1988",
        //        JobTitleId = Guid.NewGuid()
        //    });

        ////Act
        //var result = _validator.Validate(command);

        ////Assert
        //Assert.False(result.IsValid);

    }

    [Fact]
    public void Validator_ShouldReturnFalse_WhenLastNameIsIncorrect()
    {
        ////Arrange
        //CreateEmployeeCommand command = new CreateEmployeeCommand(
        //    new EmployeeDto
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Test",
        //        LastName = "",
        //        PhoneNumber = "89561472312",
        //        BirthDate = "25.10.1988",
        //        JobTitleId = Guid.NewGuid()
        //    });

        ////Act
        //var result = _validator.Validate(command);

        ////Assert
        //Assert.False(result.IsValid);

    }
    [Fact]
    public void Validator_ShouldReturnFalse_WhenPhoneNumberIsIncorrect()
    {
        ////Arrange
        //CreateEmployeeCommand command = new CreateEmployeeCommand(
        //    new EmployeeDto
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Test",
        //        LastName = "Test",
        //        PhoneNumber = "Test",
        //        BirthDate = "25.10.1988",
        //        JobTitleId = Guid.NewGuid()
        //    });

        ////Act
        //var result = _validator.Validate(command);

        ////Assert
        //Assert.False(result.IsValid);

    }

}
