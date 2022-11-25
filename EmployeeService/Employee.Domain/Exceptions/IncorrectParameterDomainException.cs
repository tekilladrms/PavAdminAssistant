
namespace EmployeeService.Domain.Exceptions;
public sealed class IncorrectParameterDomainException : DomainException
{
    public IncorrectParameterDomainException(string message) : base(message)
    {
    }
}