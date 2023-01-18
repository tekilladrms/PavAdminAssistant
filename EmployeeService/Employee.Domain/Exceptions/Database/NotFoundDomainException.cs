namespace EmployeeService.Domain.Exceptions.Database;
public sealed class NotFoundDomainException : DomainException
{
    public NotFoundDomainException(string message) : base(message)
    {
    }
}