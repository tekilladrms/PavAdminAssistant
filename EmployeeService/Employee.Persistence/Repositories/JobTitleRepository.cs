using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Threading;
using EmployeeService.Domain.Exceptions.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Primitives;
using SharedKernel.Repositories;
using System.Linq;

namespace EmployeeService.Persistence.Repositories;

public class JobTitleRepository : IJobTitleRepository
{
    private readonly ApplicationDbContext _context;
    public JobTitleRepository(ApplicationDbContext dbContext) => _context = dbContext;

    public async Task<IEnumerable<JobTitle>> GetAllAsync(CancellationToken cancellationToken)
    {
        var jobTitles = await _context.Set<JobTitle>().ToListAsync(cancellationToken);

        if (jobTitles is null || jobTitles.Count == 0) throw new NotFoundDomainException(nameof(jobTitles));

        return jobTitles;
    }

    public async Task<JobTitle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var jobTitle = await _context.Set<JobTitle>().FirstOrDefaultAsync(jt => jt.Guid == id);

        if (jobTitle is null) throw new NotFoundDomainException(nameof(jobTitle));

        return jobTitle;
    }

    public async Task<JobTitle> AddAsync(JobTitle entity, CancellationToken cancellationToken = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        var result = await _context.Set<JobTitle>().AddAsync(entity);
        return result.Entity;
    }

    public JobTitle Update(JobTitle entity, CancellationToken cancellationToken = default)
    {
        _context.Set<JobTitle>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public void Delete(Guid id, CancellationToken cancellationToken = default)
    {
        JobTitle? jt = _context.Set<JobTitle>().FirstOrDefault(jobT => jobT.Guid == id);

        if (jt is null) throw new NotFoundDomainException($"Record with Id = {id} is not exist");

        _context.Remove(jt);
    }

    public void Delete(JobTitle entity, CancellationToken cancellationToken = default)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<JobTitle>().Attach(entity);
        }
        _context.Remove(entity);
    }

}