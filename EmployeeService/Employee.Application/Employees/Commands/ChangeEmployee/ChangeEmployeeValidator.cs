using EmployeeService.Application.ValidationMethods;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;
using System;

namespace EmployeeService.Application.Employees.Commands.ChangeEmployee;

internal class ChangeEmployeeValidator : AbstractValidator<ChangeEmployeeCommand>
{
    public ChangeEmployeeValidator() 
    {
        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.Id).NotEqual(Guid.Empty);

        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.FirstName)
            .Must(CheckMethods.IsValid<Name, string>).WithMessage("First name is not valid");

        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.LastName)
            .Must(CheckMethods.IsValid<Name, string>).WithMessage("Last name is not valid");

        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.PhoneNumber)
            .Must(CheckMethods.IsValid<PhoneNumber, string>).WithMessage("Phone number is not valid");
    }

}
