
namespace EmployeeService.Domain.Exceptions;
public sealed class ArgumentIsNotValidDomainException<TValue> : DomainException
{
    public ArgumentIsNotValidDomainException(object parameter) : base($"Incorrect parameter {parameter}. Creation {typeof(TValue)} faled")
    {
    }
}