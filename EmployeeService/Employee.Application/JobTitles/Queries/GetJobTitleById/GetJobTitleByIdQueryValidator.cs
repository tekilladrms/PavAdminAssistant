using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Queries.GetJobTitleById;

internal class GetJobTitleByIdQueryValidator : AbstractValidator<GetJobTitleByIdQuery>
{
    public GetJobTitleByIdQueryValidator()
    {
        RuleFor(getJobTitleByIdQuery => getJobTitleByIdQuery.jobTitleId).NotEqual(Guid.Empty);
    }
}
