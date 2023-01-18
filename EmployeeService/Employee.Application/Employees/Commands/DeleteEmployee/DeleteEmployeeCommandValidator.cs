using EmployeeService.Application.ValidationMethods;
using FluentValidation;

namespace EmployeeService.Application.Employees.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(deleteEmployeeCommand => deleteEmployeeCommand.Guid)
                .Must(CheckMethods.IsGuid).WithMessage("employeeId must be guid");
        }
    }
}
