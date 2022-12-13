using EmployeeService.Domain.Entities;
using EmployeeService.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Tests.ApplicationTests.Fakes
{
    internal class FakeDbContext : DbContext
    {
        DbSet<Employee> Employees => Set<Employee>();
        DbSet<JobTitle> JobTitles => Set<JobTitle>();

        public FakeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new JobTitleConfiguration());
        }
    }
}
