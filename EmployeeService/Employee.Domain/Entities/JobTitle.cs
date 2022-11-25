using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.Enums;
using System.Collections.Generic;
using System;
using SharedKernel.Primitives;
using EmployeeService.Domain.ValueObjects;

namespace EmployeeService.Domain.Entities;
public class JobTitle : Entity
{
    public Name JobTitleName { get; private set; }

    public Salary Salary { get; private set; }

    public PercentageOfSales PercentageOfSales { get; private set; }

    //for EF
    private JobTitle(Guid id) : base(id) { }

    private JobTitle(Guid id, Name name, Salary salary, PercentageOfSales percentageOfSales) : base(id)
    {
        JobTitleName = name;
        Salary = salary;
        PercentageOfSales = percentageOfSales;
    }

    public static JobTitle Create(Guid id, Name name, Salary salary, PercentageOfSales percentageOfSales)
    {
        if (name is null) throw new ArgumentNullDomainException(nameof(name));
        if (salary is null) throw new ArgumentNullDomainException(nameof(salary));
        if (percentageOfSales is null) throw new ArgumentNullDomainException(nameof(percentageOfSales));
        

        return new JobTitle(id, name, salary, percentageOfSales);
    }

    
    public void ChangeName(Name newJobTitleName)
    {
        if (newJobTitleName is null) throw new ArgumentNullDomainException(nameof(newJobTitleName));
        JobTitleName = newJobTitleName;
    }

    public void ChangeSalary(Salary newSalary)
    {
        if (newSalary is null) throw new ArgumentNullDomainException(nameof(newSalary));

        Salary = newSalary;
    }

    public void ChangePercentageOfSales(PercentageOfSales newPercentageOfSales)
    {
        if (newPercentageOfSales is null) throw new ArgumentNullDomainException(nameof(newPercentageOfSales));

        PercentageOfSales = newPercentageOfSales;
    }



}