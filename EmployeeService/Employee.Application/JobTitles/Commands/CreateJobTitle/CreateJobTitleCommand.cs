using EmployeeService.Application.DTO;
using MediatR;

namespace EmployeeService.Application.JobTitles.CreateJobTitle;

public sealed record CreateJobTitleCommand(JobTitleDto JobTitleDto) : IRequest<JobTitleDto>;