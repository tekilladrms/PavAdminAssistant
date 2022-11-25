using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using MediatR;
using System;

namespace EmployeeService.Application.Employees.Queries.GetEmployeeById;

public sealed record GetEmployeeByIdQuery(Guid Employeeid) : IRequest<EmployeeDto>;