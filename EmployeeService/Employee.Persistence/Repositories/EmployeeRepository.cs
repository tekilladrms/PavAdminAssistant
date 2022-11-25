using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Data.Entity;
using SharedKernel.Repositories;
using EmployeeService.Domain.Exceptions;
using System.Data.Entity.Migrations;
using EmployeeService.Domain.Exceptions.Database;
using System.Collections.Generic;

namespace EmployeeService.Persistence.Repositories;
internal sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        var employees = await _dbContext.Set<Employee>().AsNoTracking().ToListAsync(cancellationToken);

        if (employees is null ||  employees.Count == 0) throw new RecordsNotFoundException(nameof(employees));

        return employees;
    }

    public async Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _dbContext.Set<Employee>().AsNoTracking()
            .FirstOrDefaultAsync(emp => emp.Guid == id, cancellationToken);

        if (employee is null) throw new RecordsNotFoundException(nameof(employee));

        return employee;
    }
    public void Add(Employee employee)
    {
        _dbContext.Set<Employee>().Add(employee);
    }

    public void Remove(Guid id)
    {
        var employee = GetByIdAsync(id).Result;

        if (employee is null) throw new EmployeeNotFoundException(nameof(employee));

        _dbContext.Set<Employee>().Remove(employee);
    }

    public void Update(Employee employee)
    {

        _dbContext.Set<Employee>().AddOrUpdate(employee);
    }
}
