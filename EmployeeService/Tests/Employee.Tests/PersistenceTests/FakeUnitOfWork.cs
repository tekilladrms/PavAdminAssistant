using EmployeeService.Domain.Repositories;
using EmployeeService.Persistence;
using EmployeeService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Tests.PersistenceTests
{
    internal class FakeUnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        private ApplicationDbContext _context;

        private EmployeeRepository? _employeeRepository;
        private JobTitleRepository? _jobTitleRepository;
        IEmployeeRepository IUnitOfWork.EmployeeRepository => _employeeRepository ?? new EmployeeRepository(_context);
        IJobTitleRepository IUnitOfWork.JobTitleRepository => _jobTitleRepository ?? new JobTitleRepository(_context);

        public FakeUnitOfWork(ApplicationDbContext context, EmployeeRepository? employeeRepository, JobTitleRepository? jobTitleRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _jobTitleRepository = jobTitleRepository;
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
}
