using SharedKernel.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IUnitOfWork : IDisposable
{
    
    Task SaveChangesAsync();
}
