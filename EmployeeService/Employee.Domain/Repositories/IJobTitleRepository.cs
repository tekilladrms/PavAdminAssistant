using EmployeeService.Domain.Entities;
using SharedKernel.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IJobTitleRepository : IRepository<JobTitle>
{
    Task<JobTitle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(JobTitle jobTitle);
    void Remove(Guid id);

    void Update(JobTitle jobTitle);
}