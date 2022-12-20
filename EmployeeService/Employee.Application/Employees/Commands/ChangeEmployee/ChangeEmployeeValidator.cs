using EmployeeService.Application.ValidationMethod;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.ChangeEmployee;

internal class ChangeEmployeeValidator : AbstractValidator<ChangeEmployeeCommand>
{
    public ChangeEmployeeValidator() 
    {
        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.Id).NotEqual(Guid.Empty);
        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.FirstName).Must(CheckMethods.IsValid<Name, string>);
        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.LastName).Must(CheckMethods.IsValid<Name, string>);
        RuleFor(changeEmployeeCommand => changeEmployeeCommand.employeeDto.PhoneNumber).Must(CheckMethods.IsValid<PhoneNumber, string>);
    }

}
