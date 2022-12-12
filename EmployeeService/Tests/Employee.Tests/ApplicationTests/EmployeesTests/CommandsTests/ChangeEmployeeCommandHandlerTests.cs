
using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.ChangeEmployee;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class ChangeEmployeeCommandHandlerTests
{
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;
    private readonly Guid _id;

    public ChangeEmployeeCommandHandlerTests()
    {
        _id = Guid.NewGuid();

        _employeeRepositoryMock = new();
        _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(_id, default)).Returns(GetTestData());

        _unitOfWorkMock = new();

        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    private async Task<Employee> GetTestData()
    {
        var employee = Employee.Create(
                _id,
            "Firstname",
            "Lastname",
            "87654321111",
            DateOnly.Parse("25.10.1988"),
            Guid.NewGuid()
            );
        return employee;
    }

    [Fact]
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

        var handler = new ChangeEmployeeCommandHandler(_unitOfWorkMock.Object, _employeeRepositoryMock.Object, _mapper);

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
