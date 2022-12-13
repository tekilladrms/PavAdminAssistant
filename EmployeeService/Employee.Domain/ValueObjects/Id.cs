using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System;
using System.Collections.Generic;

namespace EmployeeService.Domain.ValueObjects;
public class Id : ValueObject
{
    public Guid Guid { get; private set; } = Guid.NewGuid();
    public Email Email { get; private set; } = Email.Create(string.Empty);
    public PhoneNumber PhoneNumber { get; private set; } = PhoneNumber.Create(string.Empty);
    public DateOnly DateOnly { get; private set; } = DateOnly.MinValue;

    public Id(Email email)
    {
        if (email is null) throw new ArgumentNullDomainException(nameof(email));
        Email = email;
    }
    public Id(PhoneNumber phoneNumber)
    {
        if (phoneNumber is null) throw new ArgumentNullDomainException(nameof(phoneNumber));
        PhoneNumber = phoneNumber;
    }
    public Id(DateOnly dateOnly)
    {
        if (dateOnly == DateOnly.MinValue) throw new IncorrectParameterDomainException(nameof(dateOnly));
        DateOnly = dateOnly;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Guid;
        yield return Email;
        yield return PhoneNumber;
        yield return DateOnly;
    }
}