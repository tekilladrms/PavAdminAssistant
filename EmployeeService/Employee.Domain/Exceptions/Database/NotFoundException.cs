namespace EmployeeService.Domain.Exceptions.Database;
public sealed class NotFoundException : DomainException
{
    public NotFoundException(string message) : base(message)
    {
    }
}