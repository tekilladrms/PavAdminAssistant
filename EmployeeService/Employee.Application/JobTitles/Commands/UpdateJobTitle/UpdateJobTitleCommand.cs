using EmployeeService.Application.DTO;
using EmployeeService.Domain.Enums;
using MediatR;
using System;

namespace EmployeeService.Application.JobTitles.Commands.ChangeJobTitle;

public sealed record UpdateJobTitleCommand(
    string Guid,
    string JobTitleName,
    decimal SalaryAmount,
    Currency SalaryCurrency,
    SalaryType SalaryType,
    decimal PercentageOfSales) : IRequest<JobTitleDto>;
