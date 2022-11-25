using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.SetJobTitleIdToEmployee;

public class SetJobTitleIdToEmployeeCommandHandler : IRequestHandler<SetJobTitleIdToEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetJobTitleIdToEmployeeCommandHandler(IEmployeeRepository employeeRepository, IJobTitleRepository jobTitleRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _jobTitleRepository = jobTitleRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(SetJobTitleIdToEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);

        if (employee is null)
        {
            throw new RecordsNotFoundException(nameof(employee));
        }

        var jobTitle = await _jobTitleRepository.GetByIdAsync(request.JobTitleId);

        if (jobTitle is null)
        {
            throw new RecordsNotFoundException(nameof(jobTitle));
        }

        employee.ChangeJobTitleId(request.JobTitleId);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
