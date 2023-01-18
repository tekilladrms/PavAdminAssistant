using EmployeeService.Application.ValidationMethods;
using EmployeeService.Domain.ValueObjects;
using FluentValidation;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

internal class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
	public CreateEmployeeCommandValidator()
	{

		RuleFor(createEmployeeCommand => createEmployeeCommand.FirstName)
			.Must(CheckMethods.IsValid<Name, string>)
			.WithMessage("FirstName is not valid");

		RuleFor(createEmployeeCommand => createEmployeeCommand.LastName)
			.Must(CheckMethods.IsValid<Name, string>)
			.WithMessage("LastName is not valid");

		RuleFor(createEmployeeCommand => createEmployeeCommand.PhoneNumber)
			.Must(CheckMethods.IsValid<PhoneNumber, string>)
			.WithMessage("PhoneNumber is not valid");

	}

}
