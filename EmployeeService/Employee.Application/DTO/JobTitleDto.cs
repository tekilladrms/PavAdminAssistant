using EmployeeService.Domain.Enums;
using System;

namespace EmployeeService.Application.DTO;

public class JobTitleDto
{
    public Guid Id { get; set; }
    public string JobTitleName { get; set; } = string.Empty;
    public decimal SalaryAmount { get; set; } = default;
    public Currency SalaryCurrency { get; set; } = Currency.RUB;
    public SalaryType SalaryType { get; set; }
    public decimal PercentageOfSales {  get; set; } = default;


}