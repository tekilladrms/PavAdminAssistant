using EmployeeService.Application.ValidationMethods;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.ChangeJobTitle
{
    public class UpdateJobTitleCommandValidator  : AbstractValidator<UpdateJobTitleCommand>
    {
        public UpdateJobTitleCommandValidator()
        {
            RuleFor(changeJobTitleCommand => changeJobTitleCommand.Guid)
                .Must(CheckMethods.IsGuid).WithMessage("jobTitleId must be guid");

            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleName)
                .Must(CheckMethods.IsValid<Name, string>).WithMessage("JobTitleName is not valid");

            RuleFor(createJobTitleCommand => createJobTitleCommand.SalaryAmount)
                .Must(CheckMethods.IsValid<Salary, decimal>).WithMessage("SalaryAmount is not valid");

            RuleFor(createJobTitleCommand => createJobTitleCommand.PercentageOfSales)
                .Must(CheckMethods.IsValid<PercentageOfSales, decimal>).WithMessage("PercentageOfSales is not valid");
        }
    }
}
