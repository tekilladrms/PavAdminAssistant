
using AutoMapper;
using EmployeeService.Application;
using EmployeeService.Application.DTO;
using EmployeeService.Application.Employees.Commands.CreateEmployee;
using EmployeeService.Domain.Repositories;
using Moq;
using System;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.EmployeesTests.CommandsTests;

public class CreateEmployeeCommandHandlerTests
{
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandlerTests()
    {
        _employeeRepositoryMock = new();
        _unitOfWorkMock = new();
        var mapProfile = new MapProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mapProfile));
        _mapper = new Mapper(config);
    }

    //[Fact]
    //public async Task Handle_Should_ReturnDTO_WhenAllParametersAreCorrect()
    //{
    //    // Arrange
    //    var command = new CreateEmployeeCommand(
    //        new EmployeeDto {
    //            Id = Guid.NewGuid(),
    //            FirstName = "FirstName",
    //            LastName = "LastName",
    //            PhoneNumber = "87654321111",
    //            BirthDate = "25.10.1988",
    //            JobTitleId = Guid.NewGuid()
    //            });

    //    var handler = new CreateEmployeeCommandHandler(_unitOfWorkMock.Object, _employeeRepositoryMock.Object, _mapper);

    //    // Act
    //    var result = await handler.Handle(command, default);

    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.Equal(command.employeeDto.FirstName, result.FirstName);
    //}
}