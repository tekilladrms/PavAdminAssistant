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
                _id,
                Name.Create("Admin"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Guid.NewGuid(),
                Name.Create("Sound"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Guid.NewGuid(),
                Name.Create("Owner"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                ),
            JobTitle.Create(
                Guid.NewGuid(),
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
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act
        var result = _jobTitleRepository.GetByIdAsync(_id);

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
        Assert.ThrowsAsync<RecordsNotFoundException>(() => _jobTitleRepository.GetByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public void Add_Should_AddJobTitleInDatabase()
    {
        // Arrange
        Guid testGuid = Guid.NewGuid();
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act
        _jobTitleRepository.Add(
            JobTitle.Create(
                testGuid,
                Name.Create("CEO"),
                Salary.Create(Money.Create(150, Domain.Enums.Currency.RUB), Domain.Enums.SalaryType.PerHour),
                PercentageOfSales.Create(0)
                )
            );
        var result = _jobTitleRepository.GetByIdAsync(testGuid);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Remove_Should_RemoveJobTitleFromDatabase()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act

        _jobTitleRepository.Delete(_id);

        // Assert
        Assert.ThrowsAsync<RecordsNotFoundException>(() => _jobTitleRepository.GetByIdAsync(_id));
    }

    [Fact]
    public async Task Update_Should_UpdateRecordInDatabase()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<JobTitle>()).ReturnsDbSet(GetAll());

        // Act
        var jt = await _jobTitleRepository.GetByIdAsync(_id);
        jt.ChangeName(Name.Create("SEO"));

        _jobTitleRepository.Update(jt);

        // Assert
        Assert.Equal(jt.JobTitleName.Value, _jobTitleRepository.GetByIdAsync(_id).Result.JobTitleName.Value);
    }
}