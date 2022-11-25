using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;
using System;

namespace EmployeeService.Tests.DomainTests.EntitiesTests;

public class EmployeeTests
{
    private Employee _employee;
    private DateOnly _birthDate = new DateOnly(1988, 10, 25);
    public EmployeeTests()
    {
        _birthDate = new DateOnly(1988, 10, 25);
        _employee = Employee.Create(Guid.NewGuid(), "Alex", "Fedurin", "89659001995", _birthDate, Guid.NewGuid());
    }

    [Theory]
    [InlineData(null, "Fedurin", "89659001995")]
    [InlineData("Alex", null, "89659001995")]
    [InlineData("Alex", "Fedurin", null)]
    public void CreateEmployeeWithNullArgumentsThrowsException(
        string firstName, 
        string lastName,
        string phoneNumber)
    {
        Assert.Throws<ArgumentNullDomainException>(() => Employee.Create(Guid.NewGuid(), firstName, lastName, phoneNumber, _birthDate, Guid.NewGuid()));
    }

    [Theory]
    [InlineData("Alex", "Fedurin", "89659001995")]
    public void CreateEmployeeWithCorrectArgumentsReturnsInstance(
        string firstName,
        string lastName,
        string phoneNumber)
    {
        Assert.NotNull(Employee.Create(Guid.NewGuid(), firstName, lastName, phoneNumber, _birthDate, Guid.NewGuid()));
    }

    

    [Theory]
    [InlineData("Alexey")]
    public void ChangeFirstNameWithCorrectParameterIsChangesFirstName(string firstName)
    {
        //Arrange
        var resultName = Name.Create(firstName);

        //Act
        _employee.ChangeFirstName(firstName);

        //Assert
        Assert.Equal(resultName, _employee.FirstName);
    }

    [Theory]
    [InlineData("Alexey")]
    public void ChangeLastNameWithCorrectParameterIsChangesLastName(string lastName)
    {
        //Arrange
        var resultName = Name.Create(lastName);

        //Act
        _employee.ChangeLastName(lastName);

        //Assert
        Assert.Equal(resultName, _employee.LastName);
    }


    [Theory]
    [InlineData("89659001999")]
    public void ChangePhoneNumberWithCorrectParameterIsChangesPhoneNumber(string phoneNumber)
    {
        //Arrange
        var resultPhoneNumber = PhoneNumber.Create(phoneNumber);

        //Act
        _employee.ChangePhoneNumber(phoneNumber);

        //Assert
        Assert.Equal(resultPhoneNumber, _employee.PhoneNumber);
    }

    [Theory]
    [InlineData("26.10.1989")]
    public void ChangeBirthDateWithCorrectParameterIsChangesBirthDate(string birthDate)
    {
        //Arrange
        var resultBirthDate = DateOnly.Parse(birthDate);

        //Act
        _employee.ChangeBirthDate(birthDate);

        //Assert
        Assert.Equal(resultBirthDate, _employee.BirthDate);
    }

}