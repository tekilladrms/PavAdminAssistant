using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Enums;
using EmployeeService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmployeeService.Persistence.Configurations;

public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
{
    public void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        builder.HasKey(jt => jt.Guid);

        builder.OwnsOne(jt => jt.JobTitleName).Property(prop => prop.Value).HasColumnName<string>("JobTitleName");

        builder.OwnsOne(jt => jt.Salary,
            navigationBuilder =>
            {
                navigationBuilder
                .Property(salary => salary.SalaryType)
                .HasConversion(
                    value => value.ToString(),
                    value => (SalaryType)Enum.Parse(typeof(SalaryType), value));
            });

        builder.OwnsOne(jt => jt.Salary.Money, 
            navigationBuilder =>
            {
                navigationBuilder
                .Property(money => money.Amount)
                .HasColumnName<decimal>("Amount");

                navigationBuilder
                .Property(money => money.Currency)
                .HasConversion(
                    value => value.ToString(),
                    value => (Currency)Enum.Parse(typeof(Currency), value));
            });
        
    }
}
