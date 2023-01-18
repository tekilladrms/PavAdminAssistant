using EmployeeService.Application.DTO;
using MediatR;

namespace EmployeeService.Application.Employees.Commands.UpdateEmployee;

public sealed record UpdateEmployeeCommand(
    string Guid,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string BirthDate) : IRequest<EmployeeDto>;