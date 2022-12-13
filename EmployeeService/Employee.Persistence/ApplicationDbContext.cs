using EmployeeService.Domain.Entities;
using EmployeeService.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Persistence;

public class ApplicationDbContext : DbContext
{
    DbSet<Employee> Employees => Set<Employee>();
    DbSet<JobTitle> JobTitles => Set<JobTitle>();

    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new JobTitleConfiguration());
    }
}