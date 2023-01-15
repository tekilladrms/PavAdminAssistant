using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Enums;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;
using System;

namespace EmployeeService.Tests.DomainTests.EntitiesTests;

public class JobTitleTests
{
    [Theory]
    [InlineData(null, 0, Currency.USD, SalaryType.PerHour, 0)]
    [InlineData("", 0, Currency.RUB, SalaryType.PerHour, 0)]
    [InlineData("      ", 0, Currency.EUR, SalaryType.PerHour, 0)]
    public void CreateJobTitleWithNullOrWhiteSpaceNameParameterThrowingException(string name, decimal salaryAmount, Currency salaryCurrency, SalaryType salaryType, decimal percentageOfSales)
    {
        Assert.Throws<ArgumentNullDomainException>(() => JobTitle.Create(
            Name.Create(name),
            Salary.Create(Money.Create(salaryAmount, salaryCurrency), salaryType),
            PercentageOfSales.Create(percentageOfSales)));
    }

    [Theory]
    [InlineData("Admin  ", -1, Currency.USD, SalaryType.PerHour, -0.5)]
    [InlineData("Admin  ", -0.5, Currency.USD, SalaryType.PerHour, -1)]
    public void CreateJobTitleWithIncorrectSalaryAndPercentageOfSalesParametersThrowingException(string name, decimal salaryAmount, Currency salaryCurrency, SalaryType salaryType, decimal percentageOfSales)
    {
        Assert.Throws<ArgumentIsNotValidDomainException<JobTitle>>(() => JobTitle.Create(
            Name.Create(name),
            Salary.Create(Money.Create(salaryAmount, salaryCurrency), salaryType),
            PercentageOfSales.Create(percentageOfSales)));
    }

    [Theory]
    [InlineData("Administrator", 230, Currency.RUB, SalaryType.PerHour, 1)]
    public void CreateJobTitleWithCorrectParametersReturnsInstance(string name, decimal salaryAmount, Currency salaryCurrency, SalaryType salaryType, decimal percentageOfSales)
    {
        Assert.NotNull(JobTitle.Create(
            Name.Create(name),
            Salary.Create(Money.Create(salaryAmount, salaryCurrency), salaryType),
            PercentageOfSales.Create(percentageOfSales)));
    }
}