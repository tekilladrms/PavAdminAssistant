using EmployeeService.Application.ValidationMethod;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.ChangeJobTitle
{
    public class ChangeJobTitleCommandValidator  : AbstractValidator<ChangeJobTitleCommand>
    {
        public ChangeJobTitleCommandValidator()
        {
            RuleFor(changeJobTitleCommand => changeJobTitleCommand.JobTitleDto.Id).NotEqual(Guid.Empty);
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleDto.JobTitleName).Must(CheckMethods.IsValid<Name, string>);
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleDto.SalaryAmount).Must(CheckMethods.IsValid<Salary, decimal>);
            RuleFor(createJobTitleCommand => createJobTitleCommand.JobTitleDto.PercentageOfSales).Must(CheckMethods.IsValid<PercentageOfSales, decimal>);
        }
    }
}
