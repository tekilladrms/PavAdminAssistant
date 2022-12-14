
using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.ChangeEmployee;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using EmployeeService.Persistence;
using EmployeeService.Persistence.Repositories;
using EmployeeService.Tests.PersistenceTests;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class ChangeEmployeeCommandHandlerTests
{
    private readonly Mock<ApplicationDbContext> _appDbContextMock;
    private readonly Mock<EmployeeRepository> _employeeRepositoryMock;
    private readonly FakeUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly Guid _id;

    public ChangeEmployeeCommandHandlerTests()
    {
        _id = Guid.NewGuid();
        _appDbContextMock = new();
        _appDbContextMock.Setup(ctx => ctx.Set<Employee>()).ReturnsDbSet(GetTestDataCollection(), new Mock<DbSet<Employee>>());
        _employeeRepositoryMock = new(_appDbContextMock.Object);

        _unitOfWork = new(_appDbContextMock.Object, _employeeRepositoryMock.Object, null);

        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    private List<Employee> GetTestDataCollection()
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

    
    public async Task Handle_Should_ReturnDTO_WhenAllParametersAreCorrect()
    {
        // Arrange
        var employeeDto = new EmployeeDto
        {
            Id = _id,
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "87654321111",
            BirthDate = "25.10.1988",
            JobTitleId = Guid.NewGuid()
        };



        var command = new ChangeEmployeeCommand(
            new EmployeeDto
            {
                Id = _id,
                FirstName = "Alex",
                LastName = "Fedurin",
                PhoneNumber = "87654320000",
                BirthDate = "25.10.1990",
                JobTitleId = Guid.NewGuid()
            }
            );

        var handler = new ChangeEmployeeCommandHandler(_unitOfWork, _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<EmployeeDto>(result);
        Assert.Equal(command.employeeDto.FirstName, result.FirstName);
        Assert.Equal(command.employeeDto.LastName, result.LastName);
        Assert.Equal(command.employeeDto.PhoneNumber, result.PhoneNumber);
        Assert.Equal(command.employeeDto.BirthDate, result.BirthDate);
    }

}
