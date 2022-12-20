﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;

public class DeleteJobTitleCommandValidator : AbstractValidator<DeleteJobTitleCommand>
{
    public DeleteJobTitleCommandValidator()
    {
        RuleFor(deleteJobTitleCommand => deleteJobTitleCommand.Id).NotEqual(Guid.Empty);
    }
}
