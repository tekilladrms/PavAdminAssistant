using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Persistence;

public class ApplicationDbContext : DbContext
{
    DbSet<Employee> Employees => Set<Employee>();
    DbSet<JobTitle> JobTitles => Set<JobTitle>();
}