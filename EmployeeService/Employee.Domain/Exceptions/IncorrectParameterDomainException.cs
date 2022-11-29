
namespace EmployeeService.Domain.Exceptions;
public sealed class IncorrectParameterDomainException : DomainException
{
    public IncorrectParameterDomainException(object parameter) : base($"{parameter} is incorrect")
    {
    }
}