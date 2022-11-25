using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IJobTitleRepository jobTitleRepository)
    {
        _unitOfWork = unitOfWork;
        _jobTitleRepository = jobTitleRepository;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        _jobTitleRepository.Remove(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}