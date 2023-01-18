using EmployeeService.Application.ValidationMethods;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;

namespace EmployeeService.Application.Employees.Commands.UpdateEmployee;

internal class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator() 
    {
        RuleFor(updateEmployeeCommand => updateEmployeeCommand.Guid)
            .Must(CheckMethods.IsGuid).WithMessage("employeeId must be guid");

        RuleFor(updateEmployeeCommand => updateEmployeeCommand.FirstName)
            .Must(CheckMethods.IsValid<Name, string>).WithMessage("First name is not valid");

        RuleFor(updateEmployeeCommand => updateEmployeeCommand.LastName)
            .Must(CheckMethods.IsValid<Name, string>).WithMessage("Last name is not valid");

        RuleFor(updateEmployeeCommand => updateEmployeeCommand.PhoneNumber)
            .Must(CheckMethods.IsValid<PhoneNumber, string>).WithMessage("Phone number is not valid");
    }

}
