using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Enums;
using MediatR;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(EmployeeDto employeeDto) : IRequest<EmployeeDto>;

//public sealed record CreateEmployeeCommand(
//    string FirstName,
//    string LastName,
//    string PhoneNumber,
//    string BirthDate
//    ) : IRequest<EmployeeDto>;
