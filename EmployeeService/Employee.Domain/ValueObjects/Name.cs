
using EmployeeService.Domain.Exceptions;
using SharedKernel.Interfaces;
using SharedKernel.Primitives;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmployeeService.Domain.ValueObjects;
public class Name : ValueObject, IValidable<string>
{
    public string Value { get; private set; } = string.Empty;

    //for EF
    private Name() { }

    private Name(string value) => Value = value;


    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullDomainException(nameof(value));
        if (!IsValid(value)) throw new ArgumentIsNotValidDomainException<string>(nameof(value));
        return new Name(value);
    }

    public static bool IsValid(string value)
    {
        string pattern = @"(?=^.{1,20}$)\w\D";
        var isMatch = Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
        return isMatch;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    
}