using AutoMapper;
using EmployeeService.Application.Employees.Commands.ChangeEmployee;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
    }
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        _employeeRepository.Remove(request.id);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}