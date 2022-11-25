using EmployeeService.Domain.Enums;
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
    public Guid JobTitleId { get; private set; }

    //for EF
    private Employee(Guid id) : base(id) { }
    private Employee(
        Guid id, 
        Name firstName, 
        Name lastName,
        PhoneNumber phoneNumber,
        DateOnly birthDate,
        Guid jobTitleId) 
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        IsActive = true;
        JobTitleId = jobTitleId;
    }

    public static Employee Create(
        Guid id,
        string firstName,
        string lastName,
        string phoneNumber,
        DateOnly birthDate,
        Guid jobTitleId
        )
    {
        if(firstName is null) throw new ArgumentNullDomainException(nameof(firstName));
        if(lastName is null) throw new ArgumentNullDomainException(nameof(lastName));
        if(phoneNumber is null) throw new ArgumentNullDomainException(nameof(phoneNumber));


        return new Employee(
            id, Name.Create(firstName), 
            Name.Create(lastName),
            PhoneNumber.Create(phoneNumber),
            birthDate,
            jobTitleId);
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

    public void ChangeJobTitleId(Guid id)
    {
        JobTitleId = id;
    }
}