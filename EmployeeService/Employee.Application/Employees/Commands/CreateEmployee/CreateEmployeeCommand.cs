using EmployeeService.Application.DTO;
using MediatR;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(EmployeeDto employeeDto) : IRequest<EmployeeDto>;

