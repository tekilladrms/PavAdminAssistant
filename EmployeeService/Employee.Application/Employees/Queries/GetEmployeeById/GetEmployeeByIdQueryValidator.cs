using EmployeeService.Application.ValidationMethods;
using FluentValidation;

namespace EmployeeService.Application.Employees.Queries.GetEmployeeById;

internal class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdQueryValidator()
    {
        RuleFor(getEmployeeByIdQuery => getEmployeeByIdQuery.EmployeeId)
            .Must(CheckMethods.IsGuid)
            .WithMessage("employeeId must be guid");
    }
}
