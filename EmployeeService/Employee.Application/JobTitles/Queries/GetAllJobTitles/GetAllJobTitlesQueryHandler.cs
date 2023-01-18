using AutoMapper;
using Dapper;
using EmployeeService.Application.Abstractions;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Exceptions.Database;
using MediatR;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Queries.GetAllJobTitles;

public class GetAllJobTitlesQueryHandler : IRequestHandler<GetAllJobTitlesQuery, List<JobTitleDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllJobTitlesQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IMapper mapper)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<JobTitleDto>> Handle(GetAllJobTitlesQuery request, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = _sqlConnectionFactory.CreateConnection();

        var results = await connection.QueryAsync<JobTitleDto>(
            @"SELECT ""Guid"", ""JobTitleName"", ""Amount"", ""Currency"", ""SalaryType"", ""PercentageOfSales""
                FROM ""JobTitle""");

        if (results is null || !results.Any()) throw new NotFoundDomainException(nameof(results));

        return results.ToList();
    }
}
