using EmployeeService.Application.ValidationMethods;
using FluentValidation;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee
{
    internal class SetJobTitleIdToEmployeeCommandValidator : AbstractValidator<SetJobTitleIdToEmployeeCommand>
    {
        public SetJobTitleIdToEmployeeCommandValidator()
        {
            RuleFor(setJobTitleIdToEmployeeCommand => setJobTitleIdToEmployeeCommand.EmployeeId)
                .Must(CheckMethods.IsGuid).WithMessage("EmployeeId must be guid");

            RuleFor(setJobTitleIdToEmployeeCommand => setJobTitleIdToEmployeeCommand.JobTitleId)
                .Must(CheckMethods.IsGuid).WithMessage("JobTitleId must be guid");
        }
    }
}
