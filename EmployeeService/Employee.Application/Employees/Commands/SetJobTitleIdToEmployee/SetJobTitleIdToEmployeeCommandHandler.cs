using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee;

public class SetJobTitleIdToEmployeeCommandHandler : IRequestHandler<SetJobTitleIdToEmployeeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SetJobTitleIdToEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(SetJobTitleIdToEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.EmployeeId);

        if (employee is null)
        {
            throw new NotFoundException(nameof(employee));
        }

        var jobTitle = await _unitOfWork.JobTitleRepository.GetByIdAsync(request.JobTitleId);

        if (jobTitle is null)
        {
            throw new NotFoundException(nameof(jobTitle));
        }

        employee.ChangeJobTitleId(request.JobTitleId);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
