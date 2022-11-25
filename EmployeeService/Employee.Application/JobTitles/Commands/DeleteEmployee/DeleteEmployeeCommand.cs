using MediatR;
using System;

namespace EmployeeService.Application.JobTitles.DeleteEmployee;

public sealed record DeleteEmployeeCommand(Guid Id) : IRequest;