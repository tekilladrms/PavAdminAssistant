
using EmployeeService.Domain.Exceptions;
using SharedKernel.Interfaces;
using SharedKernel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EmployeeService.Domain.ValueObjects;
public class PhoneNumber : ValueObject, IValidable<string>
{
    public string Value { get; private set; } = string.Empty;

    //for EF
    private PhoneNumber() { }

    private PhoneNumber(string value) => Value = value;

    public static PhoneNumber Create(string value)
    {
        if (value is null) throw new ArgumentNullDomainException(nameof(value));
        if (!IsValid(value)) throw new ArgumentIsNotValidDomainException<PhoneNumber>(value);
        
        return new PhoneNumber(value);
    }

    public static bool IsValid(string value)
    {
        string pattern = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";
        Match isMatch = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

}