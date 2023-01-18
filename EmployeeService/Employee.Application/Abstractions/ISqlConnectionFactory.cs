using Npgsql;

namespace EmployeeService.Application.Abstractions
{
    public interface ISqlConnectionFactory
    {
        NpgsqlConnection CreateConnection();
    }
}
