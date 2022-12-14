using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Queries.GetJobTitleById;

public class GetJobTitleByIdQueryHandler : IRequestHandler<GetJobTitleByIdQuery, JobTitleDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetJobTitleByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<JobTitleDto> Handle(GetJobTitleByIdQuery request, CancellationToken cancellationToken)
    {
        var jobTitle = await _context.Set<JobTitle>().AsNoTracking().FirstOrDefaultAsync(jt => jt.Guid == request.jobTitleId);

        if (jobTitle is null) throw new NotFoundException(nameof(jobTitle));

        return _mapper.Map<JobTitle, JobTitleDto>(jobTitle);
    }
}
