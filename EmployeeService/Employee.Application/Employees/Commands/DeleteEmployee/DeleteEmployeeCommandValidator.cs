using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(deleteEmployeeCommand => deleteEmployeeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
