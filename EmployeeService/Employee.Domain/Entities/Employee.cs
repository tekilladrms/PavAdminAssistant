using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.ValueObjects;
using SharedKernel.Primitives;
using System;

namespace EmployeeService.Domain.Entities;
public sealed class Employee : AggregateRoot
{
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsActive { get; private set; } = false;
    public Guid JobTitleId { get; private set; } = Guid.Empty;

    //for EF
    private Employee() { }
    

    private Employee(
        string firstName,
        string lastName,
        string phoneNumber,
        DateOnly birthDate
        )
    {
        FirstName = Name.Create(firstName);
        LastName = Name.Create(lastName);
        PhoneNumber = PhoneNumber.Create(phoneNumber);
        BirthDate = birthDate;
        IsActive = true;
    }

    public static Employee Create(
        string firstName,
        string lastName,
        string phoneNumber,
        DateOnly birthDate
        )
    {
        if (firstName is null) throw new ArgumentNullDomainException(nameof(firstName));
        if (lastName is null) throw new ArgumentNullDomainException(nameof(lastName));
        if (phoneNumber is null) throw new ArgumentNullDomainException(nameof(phoneNumber));


        return new Employee(
            firstName,
            lastName,
            phoneNumber,
            birthDate);
    }

    public void ChangeFirstName(string firstName)
    {
        FirstName = Name.Create(firstName);
    }

    public void ChangeLastName(string lastName)
    {
        LastName = Name.Create(lastName);
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        PhoneNumber = PhoneNumber.Create(phoneNumber);
    }
    public void ChangeBirthDate(string birthDate)
    {
        BirthDate = DateOnly.Parse(birthDate);
    }

    public void ChangeJobTitle(Guid jobTitleId)
    {
        JobTitleId = jobTitleId;
    }
}