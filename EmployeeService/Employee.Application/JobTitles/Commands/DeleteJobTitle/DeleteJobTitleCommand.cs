using MediatR;

namespace EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;

public sealed record DeleteJobTitleCommand(string Id) : IRequest<Unit>;