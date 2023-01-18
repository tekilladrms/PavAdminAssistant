using EmployeeService.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace EmployeeService.Application.Employees.Queries.GetEmployeesByJobTitleId
{
    public sealed record GetEmployeesByJobTitleIdQuery(string JobTitleId) : IRequest<List<EmployeeDto>>;
}
