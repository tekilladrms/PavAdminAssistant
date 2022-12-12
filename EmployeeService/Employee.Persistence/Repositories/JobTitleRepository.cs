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

namespace EmployeeService.Persistence.Repositories;

public sealed class JobTitleRepository : IJobTitleRepository
{
    private readonly ApplicationDbContext _dbContext;
    public JobTitleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<JobTitle>> GetAllAsync(CancellationToken cancellationToken)
    {
        var jobTitles = await _dbContext.Set<JobTitle>().AsNoTracking().ToListAsync(cancellationToken);

        if (jobTitles is null || jobTitles.Count == 0) throw new RecordsNotFoundException(nameof(jobTitles));

        return jobTitles;
    }

    public async Task<JobTitle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var jobTitle = await _dbContext.Set<JobTitle>().AsNoTracking().FirstOrDefaultAsync(jt => jt.Guid == id);

        if (jobTitle is null) throw new RecordsNotFoundException(nameof(jobTitle));

        return jobTitle;
    }

    


    public async Task<JobTitle> Add(JobTitle entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<JobTitle>().Add(entity);
        return await GetByIdAsync(entity.Guid);
    }

    public JobTitle Update(JobTitle entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<JobTitle>().Update(entity);
        return entity;
    }

    public void Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = GetByIdAsync(id).Result;

        if (entity is null) throw new RecordsNotFoundException(nameof(entity));

        _dbContext.Set<JobTitle>().Remove(entity);
    }

    public void Delete(JobTitle entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}