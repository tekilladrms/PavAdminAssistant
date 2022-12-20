using EmployeeService.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace EmployeeService.Application.JobTitles.Queries.GetJobTitleById;

public sealed record GetJobTitleByIdQuery(Guid jobTitleId) : IRequest<JobTitleDto>;