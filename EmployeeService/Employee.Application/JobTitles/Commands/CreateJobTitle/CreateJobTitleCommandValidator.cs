using EmployeeService.Application.ValidationMethods;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;

namespace EmployeeService.Application.JobTitles.Commands.CreateJobTitle
{
    internal class CreateJobTitleCommandValidator : AbstractValidator<CreateJobTitleCommand>
    {
        public CreateJobTitleCommandValidator()
        {
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleDto.JobTitleName).Must(CheckMethods.IsValid<Name, string>);
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleDto.SalaryAmount).Must(CheckMethods.IsValid<Salary, decimal>);
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleDto.PercentageOfSales).Must(CheckMethods.IsValid<PercentageOfSales, decimal>);
        }

    }
}
