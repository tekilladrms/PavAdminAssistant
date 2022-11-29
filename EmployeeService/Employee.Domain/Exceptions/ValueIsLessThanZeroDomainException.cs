
namespace EmployeeService.Domain.Exceptions;
public sealed class ValueIsLessThanZeroDomainException : DomainException
{
    public ValueIsLessThanZeroDomainException(decimal value) : base($"{value} is invalid")
    {
    }
}