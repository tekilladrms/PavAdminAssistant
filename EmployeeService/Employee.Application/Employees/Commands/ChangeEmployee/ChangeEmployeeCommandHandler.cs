using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.ChangeEmployee;

public class ChangeEmployeeCommandHandler : IRequestHandler<ChangeEmployeeCommand, EmployeeDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ChangeEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<EmployeeDto> Handle(ChangeEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.employeeDto.Id);

        if (employee is null)
        {
            throw new RecordsNotFoundException(nameof(employee));
        }

        if (employee.FirstName.Value != request.employeeDto.FirstName)
        {
            employee.ChangeFirstName(request.employeeDto.FirstName);
        }

        if (employee.LastName.Value != request.employeeDto.LastName)
        {
            employee.ChangeLastName(request.employeeDto.LastName);
        } 

        if (employee.PhoneNumber.Value != request.employeeDto.PhoneNumber)
        {
            employee.ChangePhoneNumber(request.employeeDto.PhoneNumber);
        }

        if (employee.BirthDate.ToString() != request.employeeDto.BirthDate)
        {
            employee.ChangeBirthDate(request.employeeDto.BirthDate);
        }

        _employeeRepository.Update(employee);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(employee);
    }
}
