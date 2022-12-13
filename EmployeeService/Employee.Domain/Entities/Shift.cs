using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System;

namespace EmployeeService.Domain.Entities;
public class Shift : Entity
{
    public DateOnly Date { get; private init; } = new DateOnly();
    public decimal NumberOfHours { get; private init; } = default;
    public decimal Revenue { get; private init; } = default;


    public Shift(Guid id, DateOnly date, decimal numberOfHours, decimal revenue)
    {
        if (numberOfHours < 0) throw new ValueIsLessThanZeroDomainException(numberOfHours);
        if (revenue < 0) throw new ValueIsLessThanZeroDomainException(revenue);

        Date = date;
        NumberOfHours = numberOfHours;
        Revenue = revenue;
    }

}