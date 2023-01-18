using Dapper;
using EmployeeService.Application.Abstractions;
using EmployeeService.Application.DTO;
using MediatR;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Queries.GetEmployeesByJobTitleId
{
    internal class GetEmployeesByJobTitleIdQueryHandler : IRequestHandler<GetEmployeesByJobTitleIdQuery, List<EmployeeDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEmployeesByJobTitleIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeesByJobTitleIdQuery request, CancellationToken cancellationToken)
        {
            Guid JobTitleId;
            Guid.TryParse(request.JobTitleId, out JobTitleId);

            await using NpgsqlConnection connection = _sqlConnectionFactory.CreateConnection();

            var resultDtos = await connection.QueryAsync<EmployeeDto>(
                @"SELECT ""Guid"", ""FirstName"", ""LastName""
                    FROM ""Employees""
                    WHERE ""JobTitleId"" = @JobTitleId",
                new
                {
                    JobTitleId
                });

            return resultDtos.ToList();
        }
    }
}
