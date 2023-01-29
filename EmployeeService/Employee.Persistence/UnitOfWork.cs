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

    private ApplicationDbContext _context;

    private IEmployeeRepository _employeeRepository;
    private IJobTitleRepository _jobTitleRepository;


    IEmployeeRepository IUnitOfWork.EmployeeRepository => _employeeRepository;

    IJobTitleRepository IUnitOfWork.JobTitleRepository => _jobTitleRepository;


    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _employeeRepository = new EmployeeRepository(_context);
        _jobTitleRepository = new JobTitleRepository(_context);
    }


    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
