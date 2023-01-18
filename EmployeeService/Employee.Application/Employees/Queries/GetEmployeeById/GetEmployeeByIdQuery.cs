using EmployeeService.Application.DTO;
using MediatR;

namespace EmployeeService.Application.Employees.Queries.GetEmployeeById;

public sealed record GetEmployeeByIdQuery(string EmployeeId) : IRequest<EmployeeDto>;