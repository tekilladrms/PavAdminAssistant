using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using Moq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.DeleteEmployee;
using EmployeeService.Domain.Exceptions.Database;
using System.Linq;
using EmployeeService.Persistence;
using EmployeeService.Persistence.Repositories;
using Moq.EntityFrameworkCore;
using EmployeeService.Application.Employees.Queries.GetAllEmployees;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class DeleteEmployeeCommandHandlerTests
{
    private readonly Mock<ApplicationDbContext> _applicationDbContextMock;
    private readonly Mock<EmployeeRepository> _employeeRepositoryMock;
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly Guid _id;

    public DeleteEmployeeCommandHandlerTests()
    {
        _id = Guid.NewGuid();
        _applicationDbContextMock = new();
        _applicationDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetTestDataCollection(), new Mock<DbSet<Employee>>());
        //_unitOfWork = new UnitOfWork(_applicationDbContextMock.Object);


        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    
    private List<Employee> GetTestDataCollection()
    {
        var employees = new List<Employee>
        {
            Employee.Create(
            "Alex",
            "Fedurin",
            "87654321110",
            DateOnly.Parse("25.10.1988"),
            Guid.NewGuid()
            ),
            Employee.Create(
            "Ivan",
            "Ivanov",
            "87654321111",
            DateOnly.Parse("25.10.1989"),
            Guid.NewGuid()),
            Employee.Create(
            "Petr",
            "Petrov",
            "87654321112",
            DateOnly.Parse("25.10.1990"),
            Guid.NewGuid())
        };


        return employees;
    }

    //[Fact]
    //public async Task Handle_Should_DeleteEmployeeFromEmloyeeList()
    //{
    //    // Arrange
        
    //    var command = new DeleteEmployeeCommand(_id);
    //    var handler = new DeleteEmployeeCommandHandler(_unitOfWork);

    //    // Act
    //    await handler.Handle(command, default);

    //    // Assert
    //    await Assert.ThrowsAsync<RecordsNotFoundException>(() => _unitOfWork.EmployeeRepository.GetByIdAsync(_id));
    //}
}