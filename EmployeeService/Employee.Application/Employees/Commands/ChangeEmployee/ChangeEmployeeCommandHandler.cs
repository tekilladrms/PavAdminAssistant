using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Commands.ChangeEmployee;

public class ChangeEmployeeCommandHandler : IRequestHandler<ChangeEmployeeCommand, EmployeeDto>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ChangeEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<EmployeeDto> Handle(ChangeEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.employeeDto.Id);

        if (employee is null)
        {
            throw new NotFoundException(nameof(employee));
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

        _unitOfWork.EmployeeRepository.Update(employee);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(employee);
    }
}
