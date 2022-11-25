using EmployeeService.Domain.Exceptions;
using SharedKernel.Primitives;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace EmployeeService.Domain.ValueObjects;
public class Email : ValueObject
{
    public string Value { get; private init; } = string.Empty;

    //for EF
    private Email() { }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (value is null) throw new ArgumentNullDomainException("value cant't be null");
        if (!IsValid(value)) throw new IncorrectParameterDomainException(nameof(value));
        return new Email(value);
    }
    private static bool IsValid(string value)
    {
        string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
        Match isMatch = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    
}