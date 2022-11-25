using EmployeeService.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace EmployeeService.Application.Employees.Queries.GetAllEmployees;

public sealed record GetAllEmployeesQuery() : IRequest<List<EmployeeDto>>;