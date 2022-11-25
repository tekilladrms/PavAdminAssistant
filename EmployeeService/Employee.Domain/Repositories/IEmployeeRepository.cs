
using EmployeeService.Domain.Entities;
using SharedKernel.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Employee employee);
    void Remove(Guid id);

    void Update(Employee employee);
}