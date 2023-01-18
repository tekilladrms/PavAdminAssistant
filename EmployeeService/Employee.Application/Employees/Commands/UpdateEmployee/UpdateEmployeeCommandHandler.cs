using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Guid employeeId;
        Guid.TryParse(request.Guid, out employeeId);
        var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employeeId);

        if (employee is null)
        {
            throw new NotFoundDomainException(nameof(employee));
        }

        if (employee.FirstName.Value != request.FirstName)
        {
            employee.ChangeFirstName(request.FirstName);
        }

        if (employee.LastName.Value != request.LastName)
        {
            employee.ChangeLastName(request.LastName);
        } 

        if (employee.PhoneNumber.Value != request.PhoneNumber)
        {
            employee.ChangePhoneNumber(request.PhoneNumber);
        }

        if (employee.BirthDate.ToString() != request.BirthDate)
        {
            employee.ChangeBirthDate(request.BirthDate);
        }

        _unitOfWork.EmployeeRepository.Update(employee);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(employee);
    }
}
