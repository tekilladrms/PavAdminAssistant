using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.DeleteJobTitle;

public class DeleteJobTitleCommandHandler : IRequestHandler<DeleteJobTitleCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteJobTitleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteJobTitleCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.JobTitleRepository.Delete(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}