using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

internal sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Employee.Create(
            request.FirstName,
            request.LastName,
            request.PhoneNumber,
            DateOnly.Parse(request.BirthDate));

        await _unitOfWork.EmployeeRepository.AddAsync(employee);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(await _unitOfWork.EmployeeRepository.GetByIdAsync(employee.Guid));

    }

}