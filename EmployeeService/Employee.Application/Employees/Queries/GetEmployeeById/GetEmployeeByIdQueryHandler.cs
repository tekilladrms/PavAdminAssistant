using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Queries.GetEmployeeById;
public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

	public GetEmployeeByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {

        var employee = await _context.Set<Employee>().AsNoTracking().FirstOrDefaultAsync(emp => emp.Guid == request.EmployeeId);

        if (employee is null)
        {
            throw new RecordsNotFoundException(nameof(request.EmployeeId));
        }



        return _mapper.Map<EmployeeDto>(employee);
    }
}