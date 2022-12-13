using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;

namespace EmployeeService.Application.Employees.Commands.CreateEmployee;

internal sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var firstNameResult = Name.Create(request.employeeDto.FirstName);
        var lastNameResult = Name.Create(request.employeeDto.LastName);
        var phoneNumber = PhoneNumber.Create(request.employeeDto.PhoneNumber);
        DateOnly birthDate = DateOnly.Parse(request.employeeDto.BirthDate);
        var jobTitleId = request.employeeDto.JobTitleId;
        

        var employee = Employee.Create(
            Guid.NewGuid(),
            firstNameResult.Value,
            lastNameResult.Value,
            phoneNumber.Value,
            birthDate,
            jobTitleId);

        _unitOfWork.EmployeeRepository.Add(employee);

        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;

    }

}