using SharedKernel.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; }
    public IJobTitleRepository JobTitleRepository { get; }

    Task SaveChangesAsync();
}
