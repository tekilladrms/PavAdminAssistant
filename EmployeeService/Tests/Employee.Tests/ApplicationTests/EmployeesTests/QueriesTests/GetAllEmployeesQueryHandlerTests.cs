using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Application.Employees.Queries.GetAllEmployees;
using EmployeeService.Domain.Entities;
using EmployeeService.Persistence;
using EmployeeService.Tests.ApplicationTests.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.QueriesTests;

public class GetAllEmployeesQueryHandlerTests
{
    private Mock<DbContext> _contextMock;
    private IMapper _mapper;

    public GetAllEmployeesQueryHandlerTests()
    {
        _contextMock = new();
        _contextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(new List<Employee>
        {
            Employee.Create(Guid.NewGuid(), "Alex", "Alex", "89659001559", DateOnly.Parse("25.10.1980"), Guid.NewGuid()),
            Employee.Create(Guid.NewGuid(), "Ivan", "Ivan", "89659001558", DateOnly.Parse("25.10.1981"), Guid.NewGuid()),
            Employee.Create(Guid.NewGuid(), "Vasya", "Vasya", "89659001557", DateOnly.Parse("25.10.1982"), Guid.NewGuid()),
            Employee.Create(Guid.NewGuid(), "Vova", "Vova", "89659001556", DateOnly.Parse("25.10.1983"), Guid.NewGuid()),
            
        });

        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    [Fact]
    public async Task Handle_Should_ReturnDTOs_WhenRecordsInDatabaseAreExist()
    {
        // Arrange
        var query = new GetAllEmployeesQuery();
        //var queryHandler = new GetAllEmployeesQueryHandler(_contextMock.Object, _mapper);

        // Act
        //var result = await queryHandler.Handle(query);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Equal("Alex", result[0].FirstName);
    }
}