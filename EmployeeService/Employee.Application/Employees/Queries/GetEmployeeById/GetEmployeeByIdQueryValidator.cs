using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Queries.GetEmployeeById;

internal class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdQueryValidator()
    {
        RuleFor(getEmployeeByIdQuery => getEmployeeByIdQuery.EmployeeId).NotEqual(Guid.Empty);
    }
}
