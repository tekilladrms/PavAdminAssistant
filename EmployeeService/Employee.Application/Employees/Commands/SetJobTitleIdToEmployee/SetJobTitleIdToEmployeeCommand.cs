using MediatR;
using System;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee;

public sealed record SetJobTitleIdToEmployeeCommand(Guid JobTitleId, Guid EmployeeId) : IRequest;