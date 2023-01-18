using EmployeeService.Application.DTO;
using EmployeeService.Domain.Enums;
using MediatR;

namespace EmployeeService.Application.JobTitles.Commands.CreateJobTitle;

public sealed record CreateJobTitleCommand(
    string JobTitleName,
    decimal SalaryAmount,
    Currency SalaryCurrency,
    SalaryType SalaryType,
    decimal PercentageOfSales) : IRequest<JobTitleDto>;