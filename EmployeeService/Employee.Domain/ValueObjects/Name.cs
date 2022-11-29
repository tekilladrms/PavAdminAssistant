
using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmployeeService.Domain.ValueObjects;
public class Name : ValueObject
{
    public string Value { get; private init; } = string.Empty;

    //for EF
    private Name() { }

    private Name(string value) => Value = value;


    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullDomainException(nameof(value));
        if (!IsValid(value)) throw new IncorrectParameterDomainException(nameof(value));
        return new Name(value);
    }

    private static bool IsValid(string value)
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