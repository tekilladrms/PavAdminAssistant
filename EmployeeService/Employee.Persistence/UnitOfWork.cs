using EmployeeService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeeService.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;

    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
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
