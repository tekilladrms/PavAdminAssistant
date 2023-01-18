
using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Persistence;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class CreateEmployeeCommandHandlerTests
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandlerTests()
    {
        
        
        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    
    public async Task Handle_Should_ReturnDTO_WhenAllParametersAreCorrect()
    {
        // Arrange

        var command = new CreateEmployeeCommand(
            //new EmployeeDto
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "FirstName",
            //    LastName = "LastName",
            //    PhoneNumber = "87654321111",
            //    BirthDate = "25.10.1988",
            //    JobTitleId = Guid.NewGuid()
            //});
            "FirstName",
            "LastName",
            "87654321111",
            "25.10.1988");

        var handler = new CreateEmployeeCommandHandler(_unitOfWork, _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.FirstName, result.FirstName);
    }
}