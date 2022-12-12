using AutoMapper;
using EmployeeService.Application.Employees.Commands.ChangeEmployee;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    //private readonly IEmployeeRepository _employeeRepository;
    private readonly UnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        //await _unitOfWork.EmployeeRepository.Remove(request.id);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}