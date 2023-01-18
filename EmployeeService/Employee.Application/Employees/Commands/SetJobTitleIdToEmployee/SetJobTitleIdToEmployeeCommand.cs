using MediatR;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee;

public sealed record SetJobTitleIdToEmployeeCommand(string EmployeeId, string JobTitleId) : IRequest;