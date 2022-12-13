using EmployeeService.Application.DTO;
using MediatR;
using System;

namespace EmployeeService.Application.Employees.Commands.DeleteEmployee;

public sealed record DeleteEmployeeCommand(Guid Id) : IRequest<Unit>;