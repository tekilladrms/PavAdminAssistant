
namespace EmployeeService.Domain.Exceptions;
public sealed class ArgumentNullDomainException : DomainException
{
    public ArgumentNullDomainException(object argument) : base($"{argument} can not be null")
    {
    }
}