using EmployeeService.Application.ValidationMethods;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;

namespace EmployeeService.Application.JobTitles.Commands.CreateJobTitle
{
    internal class CreateJobTitleCommandValidator : AbstractValidator<CreateJobTitleCommand>
    {
        public CreateJobTitleCommandValidator()
        {
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleName)
                .Must(CheckMethods.IsValid<Name, string>).WithMessage("JobTitleName is not valid");

            RuleFor(createJobTitleCommand => createJobTitleCommand.SalaryAmount)
                .Must(CheckMethods.IsValid<Salary, decimal>).WithMessage("SalaryAmount is not valid");

            RuleFor(createJobTitleCommand => createJobTitleCommand.PercentageOfSales)
                .Must(CheckMethods.IsValid<PercentageOfSales, decimal>).WithMessage("PercentageOfSales is not valid");
        }

    }
}
