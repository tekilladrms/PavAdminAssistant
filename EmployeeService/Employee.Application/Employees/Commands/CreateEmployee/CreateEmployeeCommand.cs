using EmployeeService.Application.DTO;
using MediatR;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string BirthDate) : IRequest<EmployeeDto>;

