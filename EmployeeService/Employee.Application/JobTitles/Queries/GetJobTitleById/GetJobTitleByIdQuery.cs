using EmployeeService.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace EmployeeService.Application.JobTitles.GetAllJobTitleById;

public sealed record GetJobTitleByIdQuery(Guid id) : IRequest<JobTitleDto>;