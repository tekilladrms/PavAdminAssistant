using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee
{
    internal class SetJobTitleIdToEmployeeCommandValidator : AbstractValidator<SetJobTitleIdToEmployeeCommand>
    {
        public SetJobTitleIdToEmployeeCommandValidator()
        {
            RuleFor(setJobTitleIdToEmployeeCommand => setJobTitleIdToEmployeeCommand.EmployeeId).NotEqual(Guid.Empty);
            RuleFor(setJobTitleIdToEmployeeCommand => setJobTitleIdToEmployeeCommand.JobTitleId).NotEqual(Guid.Empty);
        }
    }
}
