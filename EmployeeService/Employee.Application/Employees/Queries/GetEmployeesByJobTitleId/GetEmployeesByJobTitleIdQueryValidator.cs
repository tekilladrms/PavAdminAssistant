using EmployeeService.Application.ValidationMethods;
using FluentValidation;

namespace EmployeeService.Application.Employees.Queries.GetEmployeesByJobTitleId
{
    internal class GetEmployeesByJobTitleIdQueryValidator : AbstractValidator<GetEmployeesByJobTitleIdQuery>
    {
        public GetEmployeesByJobTitleIdQueryValidator()
        {
            RuleFor(getEmployeesByJobTitleIdQuery => getEmployeesByJobTitleIdQuery.JobTitleId)
                .Must(CheckMethods.IsGuid).WithMessage("JobTitleId must be guid");
        }
    }
}
