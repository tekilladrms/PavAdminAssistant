using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllEmployeesQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken = default)
    {
        var results = await _context.Set<Employee>().AsNoTracking().ToListAsync();

        if(results is null || !results.Any())
        {
            throw new NotFoundException(nameof(results));
        }

        return _mapper.Map<List<Employee>, List<EmployeeDto>>(results);
    }

    
}