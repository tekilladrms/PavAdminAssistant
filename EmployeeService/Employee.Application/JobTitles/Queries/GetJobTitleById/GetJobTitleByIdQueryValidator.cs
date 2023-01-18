using EmployeeService.Application.ValidationMethods;
using FluentValidation;

namespace EmployeeService.Application.JobTitles.Queries.GetJobTitleById;

internal class GetJobTitleByIdQueryValidator : AbstractValidator<GetJobTitleByIdQuery>
{
    public GetJobTitleByIdQueryValidator()
    {
        RuleFor(getJobTitleByIdQuery => getJobTitleByIdQuery.JobTitleId)
            .Must(CheckMethods.IsGuid).WithMessage("JobTitleId must be guid");
    }
}
