
namespace EmployeeService.Domain.Exceptions;
public sealed class ValueIsLessThanZeroDomainException : DomainException
{
    public ValueIsLessThanZeroDomainException(string message) : base(message)
    {
    }
}