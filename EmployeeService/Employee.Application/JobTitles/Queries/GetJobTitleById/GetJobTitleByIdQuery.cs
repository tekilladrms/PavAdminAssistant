using EmployeeService.Application.DTO;
using MediatR;

namespace EmployeeService.Application.JobTitles.Queries.GetJobTitleById;

public sealed record GetJobTitleByIdQuery(string JobTitleId) : IRequest<JobTitleDto>;