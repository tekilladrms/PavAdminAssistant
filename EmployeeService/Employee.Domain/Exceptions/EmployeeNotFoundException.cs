
namespace EmployeeService.Domain.Exceptions;
public sealed class EmployeeNotFoundException : DomainException
{
    public EmployeeNotFoundException(string message) : base(message)
    {
    }
}
