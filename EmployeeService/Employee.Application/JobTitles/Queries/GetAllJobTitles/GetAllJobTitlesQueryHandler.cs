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

namespace EmployeeService.Application.JobTitles.Queries.GetAllJobTitles;

public class GetAllJobTitlesQueryHandler : IRequestHandler<GetAllJobTitlesQuery, List<JobTitleDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllJobTitlesQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<JobTitleDto>> Handle(GetAllJobTitlesQuery request, CancellationToken cancellationToken)
    {
        var jobTitles = await _context.Set<JobTitle>().AsNoTracking().ToListAsync();

        if (jobTitles is null || !jobTitles.Any()) throw new NotFoundException(nameof(jobTitles));

        return _mapper.Map<List<JobTitle>, List<JobTitleDto>>(jobTitles);
    }
}
