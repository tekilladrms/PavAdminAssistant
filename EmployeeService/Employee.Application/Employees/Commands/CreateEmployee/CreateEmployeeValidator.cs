using EmployeeService.Application.ValidationMethod;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;
using SharedKernel.Interfaces;
using SharedKernel.Primitives;
using System;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

internal class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
	public CreateEmployeeValidator()
	{
		RuleFor(createEmployeeCommand => createEmployeeCommand.employeeDto.Id).NotEqual(Guid.Empty);
		RuleFor(createEmployeeCommand => createEmployeeCommand.employeeDto.FirstName).Must(CheckMethods.IsValid<Name, string>);
		RuleFor(createEmployeeCommand => createEmployeeCommand.employeeDto.LastName).Must(CheckMethods.IsValid<Name, string>);
		RuleFor(createEmployeeCommand => createEmployeeCommand.employeeDto.PhoneNumber).Must(CheckMethods.IsValid<PhoneNumber, string>);
	}

}
