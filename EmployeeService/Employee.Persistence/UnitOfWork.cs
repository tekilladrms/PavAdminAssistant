using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeService.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;

    private ApplicationDbContext _context = new ApplicationDbContext();

    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<JobTitle> _jobTitleRepository;

    public IRepository<Employee> EmployeeRepository => _employeeRepository;

    public IRepository<JobTitle> JobTitleRepository => _jobTitleRepository;


    public UnitOfWork()
    {
        _employeeRepository = new EmployeeRepository(_context);
        _jobTitleRepository = new JobTitleRepository(_context);
    }



    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
