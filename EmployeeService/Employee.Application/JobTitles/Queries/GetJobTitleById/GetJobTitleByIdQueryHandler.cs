using Dapper;
using EmployeeService.Application.Abstractions;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Exceptions.Database;
using MediatR;
using Npgsql;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Queries.GetJobTitleById;

public class GetJobTitleByIdQueryHandler : IRequestHandler<GetJobTitleByIdQuery, JobTitleDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetJobTitleByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<JobTitleDto> Handle(GetJobTitleByIdQuery request, CancellationToken cancellationToken)
    {
        Guid jobTitleId;
        Guid.TryParse(request.JobTitleId, out jobTitleId);

        await using NpgsqlConnection connection = _sqlConnectionFactory.CreateConnection();

        var resultDto = await connection.QueryFirstOrDefaultAsync<JobTitleDto>(
            @"SELECT ""Guid"", ""JobTitleName"", ""Amount"", ""Currency"", ""SalaryType"", ""PercentageOfSales""
                FROM ""JobTitle""
                WHERE ""Guid"" = @jobTitleId", new
            {
                jobTitleId
            });

        if (resultDto is null) 
        {
            throw new NotFoundDomainException($"Not found record with id: {jobTitleId}");
        }

        return resultDto;
    }
}
