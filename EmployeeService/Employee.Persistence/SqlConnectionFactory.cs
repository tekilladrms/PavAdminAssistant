using EmployeeService.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EmployeeService.Persistence
{
    public sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public SqlConnectionFactory(IConfiguration configuration) => _configuration = configuration;


        public NpgsqlConnection CreateConnection()
        {
            var connectionString = _configuration["DbConnection"];
            return new NpgsqlConnection(connectionString);
        }
    }
}
