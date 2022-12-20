using EmployeeService.Application.DTO;
using MediatR;
using System;

namespace EmployeeService.Application.JobTitles.Commands.ChangeJobTitle;

public sealed record ChangeJobTitleCommand(JobTitleDto JobTitleDto) : IRequest<JobTitleDto>;
