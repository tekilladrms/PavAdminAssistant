
using EmployeeService.Domain.Entities;
using SharedKernel.Primitives;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IEmployeeRepository : IRepository<Employee>
{
    public Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);

    public Task<bool> IsPhoneNumberUnique(string phoneNumber);

}