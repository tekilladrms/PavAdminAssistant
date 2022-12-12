using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Persistence;
using EmployeeService.Persistence.Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Tests.PersistenceTests.RepositoriesTests;

public class EmployeeRepositoryTests
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly Mock<ApplicationDbContext> _applicationDbContextMock;
    private readonly Guid _id;

    public EmployeeRepositoryTests()
    {
        _id = Guid.NewGuid();
        _applicationDbContextMock = new();
        
        _employeeRepository = new EmployeeRepository(_applicationDbContextMock.Object);
    }


    private List<Employee> GetAll()
    {
        var employees = new List<Employee>
        {
            Employee.Create(
                _id,
            "Alex",
            "Fedurin",
            "87654321110",
            DateOnly.Parse("25.10.1988"),
            Guid.NewGuid()
            ),
            Employee.Create(
                Guid.NewGuid(),
            "Ivan",
            "Ivanov",
            "87654321111",
            DateOnly.Parse("25.10.1989"),
            Guid.NewGuid()),
            Employee.Create(
                Guid.NewGuid(),
            "Petr",
            "Petrov",
            "87654321112",
            DateOnly.Parse("25.10.1990"),
            Guid.NewGuid())
        };


        return employees;
    }

    [Fact]
    public void GetAllAsync_Should_ReturnCollectionOfEmployees_WhenCollectionIsReceived()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetAll());
        // Act
        var result = _employeeRepository.GetAllAsync();

        // Assert
        Assert.NotNull(result.Result);
        Assert.NotEmpty(result.Result);
        Assert.True(result.Result.Any());
    }


    [Fact]
    public void GetByIdAsync_Should_ReturnEmployeeInstance_WhenIdIsExistsInDB()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetAll());

        // Act
        var result = _employeeRepository.GetByIdAsync(_id);

        // Assert
        Assert.NotNull(result.Result);
        Assert.IsType<Employee>(result.Result);
    }

    [Fact]
    public void GetByIdAsync_Should_ReturnRecordsNotFoundDomainException_WhenIdIsNotExistsInDB()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetAll());

        // Act

        // Assert
        Assert.ThrowsAsync<RecordsNotFoundException>(() => _employeeRepository.GetByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public void Add_Should_AddEmployeeInDatabase()
    {
        // Arrange
        Guid testGuid = Guid.NewGuid();
        _applicationDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetAll());

        // Act
        _employeeRepository.Add(Employee.Create(
            testGuid,
            "Alexey",
            "Alexey",
            "89065435364",
            DateOnly.Parse("25.10.1988"),
            Guid.NewGuid()
            ));
        var result = _employeeRepository.GetByIdAsync(testGuid);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_Should_RemoveEmployeeFromDatabase()
    {
        // Arrange
        _applicationDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetAll());

        // Act
        
        _employeeRepository.Delete(_id);

        // Assert
        Assert.ThrowsAsync<RecordsNotFoundException>(() => _employeeRepository.GetByIdAsync(_id));
    }

}