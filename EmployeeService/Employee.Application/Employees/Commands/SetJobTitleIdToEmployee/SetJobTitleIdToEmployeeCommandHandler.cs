using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee;

public class SetJobTitleIdToEmployeeCommandHandler : IRequestHandler<SetJobTitleIdToEmployeeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public SetJobTitleIdToEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(SetJobTitleIdToEmployeeCommand request, CancellationToken cancellationToken)
    {
        Guid jobTitleId, employeeId;
        Guid.TryParse(request.JobTitleId, out jobTitleId);
        Guid.TryParse(request.EmployeeId, out employeeId);

        var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employeeId);

        if (employee is null)
        {
            throw new NotFoundDomainException(nameof(employee));
        }

        var jobTitle = await _unitOfWork.JobTitleRepository.GetByIdAsync(jobTitleId);

        if (jobTitle is null)
        {
            throw new NotFoundDomainException(nameof(jobTitle));
        }

        employee.ChangeJobTitle(jobTitle.Guid);

        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.JobTitleRepository.Update(jobTitle);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
