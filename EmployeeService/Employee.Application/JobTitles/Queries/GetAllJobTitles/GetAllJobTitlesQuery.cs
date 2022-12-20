using EmployeeService.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace EmployeeService.Application.JobTitles.Queries.GetAllJobTitles;

public sealed record GetAllJobTitlesQuery() : IRequest<List<JobTitleDto>>;