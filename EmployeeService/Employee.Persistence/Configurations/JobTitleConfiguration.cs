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
                    value => (SalaryType)Enum.Parse(typeof(SalaryType), value)).HasColumnName("SalaryType");
            });

        builder.OwnsOne(
            jt => jt.Salary, 
            salary =>
        {
            salary.OwnsOne(
                prop => prop.Money, 
                money =>
            {
                money.Property(amount => amount.Amount).HasColumnName<decimal>("Amount");
                money.Property(currency => currency.Currency).HasColumnName("Currency");
            });
        });

        builder.OwnsOne(jt => jt.PercentageOfSales).Property(prop => prop.Value).HasColumnName<decimal>("PercentageOfSales");
 
    }
}
