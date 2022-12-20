using MediatR;
using System;

namespace EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;

public sealed record DeleteJobTitleCommand(Guid Id) : IRequest;