using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Persistence.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var employees = await _context.Set<Employee>().ToListAsync();

            if (employees is null) throw new RecordsNotFoundException("no records in database");

            return employees;
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Set<Employee>().FirstOrDefaultAsync(emp => emp.Guid == id);

            if (employee is null) throw new RecordsNotFoundException($"Record with Id = {id} is not exist");

            return employee;
        }
        public async Task<Employee> Add(Employee entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Employee>().Add(entity);

            return await GetByIdAsync(entity.Guid);
        }

        public void Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var emp = GetByIdAsync(id);

            if (emp is null) throw new RecordsNotFoundException($"Record with Id = {id} is not exist");

            _context.Remove(emp);
        }

        public void Delete(Employee entity, CancellationToken cancellationToken = default)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<Employee>().Attach(entity);
            }
            _context.Remove(entity);
        }

        public Employee Update(Employee entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Employee>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
