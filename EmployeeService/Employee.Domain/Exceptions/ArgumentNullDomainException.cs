
namespace EmployeeService.Domain.Exceptions;
public sealed class ArgumentNullDomainException : DomainException
{
    public ArgumentNullDomainException(string message) : base(message)
    {
    }
}