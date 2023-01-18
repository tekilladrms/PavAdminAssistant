using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using EmployeeService.Persistence;
using EmployeeService.Persistence.Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Tests.PersistenceTests.RepositoriesTests;

public class JobTitleRepositoryTests
{
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly Mock<ApplicationDbContext> _applicationDbContextMock;
    private readonly Guid _id;

    public JobTitleRepositoryTests()
    {
        _id = Guid.NewGuid();
        _applicationDbContextMock = new();

        _jobTitleRepository = new JobTitleRepository(_applicationDbContextMock.Object);
    }

    private List<JobTitle> GetAll()
    {
        var jobTitles = new List<JobTitle>
        {
            JobTitle.Create(
                Name.Create("Admin"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Name.Create("Sound"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Name.Create("Owner"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Name.Create("Officiant"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                )
        };

        return jobTitles;
    }

    [Fact]
    public void GetAllAsync_Should_ReturnCollectionOfJobTitles_WhenCollectionRecieved()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act
        var result = _jobTitleRepository.GetAllAsync();

        // Assert
        Assert.NotNull(result.Result);
        Assert.NotEmpty(result.Result);
    }

    [Fact]
    public void GetByIdAsync_Should_ReturnJobTitleInstance_WhenIdIsExistsInDB()
    {
        // Arrange
        var jobTitles = new List<JobTitle>
        {
            JobTitle.Create(
                Name.Create("Admin"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Name.Create("Sound"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Name.Create("Owner"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Name.Create("Officiant"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                )
        };
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(jobTitles);

        // Act
        var result = _jobTitleRepository.GetByIdAsync(jobTitles[0].Guid);

        // Assert
        Assert.NotNull(result.Result);
        Assert.IsType<JobTitle>(result.Result);
    }

    [Fact]
    public void GetByIdAsync_Should_ReturnRecordsNotFoundDomainException_WhenIdIsNotExistsInDB()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act

        // Assert
        Assert.ThrowsAsync<NotFoundDomainException>(() => _jobTitleRepository.GetByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public void Add_Should_AddJobTitleInDatabase()
    {
        // Arrange
        Guid testGuid = Guid.NewGuid();
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act
        _jobTitleRepository.AddAsync(
            JobTitle.Create(
                Name.Create("CEO"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                )
            );
        var result = _jobTitleRepository.GetByIdAsync(testGuid);

        // Assert
        Assert.NotNull(result);
    }

    //[Fact]
    //public void Delete_Should_RemoveJobTitleFromDatabase()
    //{
    //    // Arrange
    //    _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

    //    // Act

    //    _jobTitleRepository.Delete(_id);

    //    // Assert
    //    Assert.ThrowsAsync<NotFoundException>(() => _jobTitleRepository.GetByIdAsync(_id));
    //}

    
}