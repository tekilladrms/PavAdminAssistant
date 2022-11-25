using MediatR;
using System;

namespace EmployeeService.Application.Employees.Commands.DeleteEmployee;

public sealed record DeleteEmployeeCommand(Guid id) : IRequest;