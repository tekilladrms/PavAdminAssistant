
using EmployeeService.Domain.Entities;
using SharedKernel.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Repositories;
public interface IEmployeeRepository : IRepository<Employee>
{
    
}