using EmployeeService.Domain.Entities;
using SharedKernel.Primitives;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IJobTitleRepository : IRepository<JobTitle>
{
    public Task<IEnumerable<JobTitle>> GetAllAsync(CancellationToken cancellationToken = default);
}