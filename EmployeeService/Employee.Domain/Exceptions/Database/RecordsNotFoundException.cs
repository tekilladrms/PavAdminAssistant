namespace EmployeeService.Domain.Exceptions.Database;
public sealed class RecordsNotFoundException : DomainException
{
    public RecordsNotFoundException(string message) : base(message)
    {
    }
}