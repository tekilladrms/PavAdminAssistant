using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;

public class DeleteJobTitleCommandHandler : IRequestHandler<DeleteJobTitleCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteJobTitleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteJobTitleCommand request, CancellationToken cancellationToken)
    {
        Guid jobTitleId;
        Guid.TryParse(request.Id, out jobTitleId);

        _unitOfWork.JobTitleRepository.Delete(jobTitleId);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}