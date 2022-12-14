using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Application.Employees.Queries.GetEmployeeById;
using EmployeeService.Domain.Entities;
using EmployeeService.Persistence;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.QueriesTests;

public class GetEmployeeByIdQueryHandlerTests
{
    private Mock<ApplicationDbContext> _contextMock;
    private IMapper _mapper;

    public GetEmployeeByIdQueryHandlerTests()
    {
        _contextMock = new();
        
        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    [Fact]
    public async Task Handle_Should_ReturnDTO_WhenRecordExistInDatabase()
    {
        // Arrange
        List<Employee> employees = new List<Employee>{
            Employee.Create(Guid.NewGuid(), "Alex", "Alex", "89659001559", DateOnly.Parse("25.10.1980"), Guid.NewGuid()),
            Employee.Create(Guid.NewGuid(), "Ivan", "Ivan", "89659001558", DateOnly.Parse("25.10.1981"), Guid.NewGuid()),
            Employee.Create(Guid.NewGuid(), "Vasya", "Vasya", "89659001557", DateOnly.Parse("25.10.1982"), Guid.NewGuid()),
            Employee.Create(Guid.NewGuid(), "Vova", "Vova", "89659001556", DateOnly.Parse("25.10.1983"), Guid.NewGuid())
        };

        var _dbSetMock = employees.AsQueryable().BuildMockDbSet();
        _contextMock.Setup(context => context.Set<Employee>()).Returns(_dbSetMock.Object);

        var query = new GetEmployeeByIdQuery(employees[0].Guid);
        var queryHandler = new GetEmployeeByIdQueryHandler(_contextMock.Object, _mapper);


        // Act
        var result = await queryHandler.Handle(query);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Alex", result.FirstName);
    }
}