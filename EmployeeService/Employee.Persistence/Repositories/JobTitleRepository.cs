using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Data.Entity;
using SharedKernel.Repositories;
using EmployeeService.Domain.Exceptions;
using System.Data.Entity.Migrations;
using System.CodeDom;
using EmployeeService.Domain.Exceptions.Database;
using System.Collections;
using System.Collections.Generic;
using EmployeeService.Domain.ValueObjects;

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
        var jobTitle = await _dbContext.Set<JobTitle>().FirstOrDefaultAsync(jt => jt.Guid == id);

        if (jobTitle is null) throw new RecordsNotFoundException(nameof(jobTitle));

        return jobTitle;
    }

    public void Add(JobTitle jobTitle)
    {
        _dbContext.Set<JobTitle>().Add(jobTitle);
    }

    public void Remove(Guid id)
    {
        var jobTitle = GetByIdAsync(id).Result;

        if (jobTitle is null) throw new RecordsNotFoundException(nameof(jobTitle));

        _dbContext.Set<JobTitle>().Remove(jobTitle);
    }

    public void Update(JobTitle jobTitle)
    {
        _dbContext.Set<JobTitle>().AddOrUpdate(jobTitle);
    }

}