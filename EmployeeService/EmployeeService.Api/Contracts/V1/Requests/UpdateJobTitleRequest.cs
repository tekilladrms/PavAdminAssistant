using EmployeeService.Domain.Enums;

namespace EmployeeService.Api.Contracts.V1.Requests
{
    public class UpdateJobTitleRequest
    {
        public string JobTitleName { get; set; } = string.Empty;
        public decimal SalaryAmount { get; set; } = default;
        public Currency SalaryCurrency { get; set; } = Currency.RUB;
        public SalaryType SalaryType { get; set; }
        public decimal PercentageOfSales { get; set; } = default;
    }
}
