using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmployeeService.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(employee => employee.Guid);
        builder.Property(employee => employee.Guid).ValueGeneratedNever();

        builder.OwnsOne(
            employee => employee.FirstName).Property(prop => prop.Value).HasColumnName<string>("FirstName");
        builder.OwnsOne(
            employee => employee.LastName).Property(prop => prop.Value).HasColumnName<string>("LastName");
        builder.OwnsOne(
            employee => employee.PhoneNumber).Property(prop => prop.Value).HasColumnName<string>("PhoneNumber");
    }
}