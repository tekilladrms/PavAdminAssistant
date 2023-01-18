using EmployeeService.Application.ValidationMethods;
using FluentValidation;
using System;
using System.ComponentModel.Design;

namespace EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;

internal class DeleteJobTitleCommandValidator : AbstractValidator<DeleteJobTitleCommand>
{
    public DeleteJobTitleCommandValidator()
    {
        RuleFor(deleteJobTitleCommand => deleteJobTitleCommand.Id)
            .Must(CheckMethods.IsGuid).WithMessage("jobTitleId must be guid");
    }
}
