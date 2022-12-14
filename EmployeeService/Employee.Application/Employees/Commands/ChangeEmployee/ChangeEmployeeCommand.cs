using EmployeeService.Application.DTO;
using MediatR;
using System;

namespace EmployeeService.Application.Employees.Commands.ChangeEmployee;

public sealed record ChangeEmployeeCommand(EmployeeDto employeeDto) : IRequest<EmployeeDto>;