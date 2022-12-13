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

    private ApplicationDbContext _context;

    private EmployeeRepository? _employeeRepository;
    private JobTitleRepository? _jobTitleRepository;


    IEmployeeRepository IUnitOfWork.EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_context);

    IJobTitleRepository IUnitOfWork.JobTitleRepository => _jobTitleRepository ??= new JobTitleRepository(_context);

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
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
