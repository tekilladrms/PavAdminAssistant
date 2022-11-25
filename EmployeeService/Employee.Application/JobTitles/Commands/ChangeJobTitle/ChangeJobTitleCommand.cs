using EmployeeService.Application.DTO;
using MediatR;
using System;

namespace EmployeeService.Application.JobTitles.ChangeJobTitle;

public sealed record ChangeJobTitleCommand(Guid id, JobTitleDto jobTitleDto) : IRequest<JobTitleDto>;
