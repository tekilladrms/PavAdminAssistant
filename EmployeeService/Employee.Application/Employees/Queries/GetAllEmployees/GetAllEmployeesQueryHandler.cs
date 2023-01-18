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

namespace EmployeeService.Application.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMapper _mapper;
    public GetAllEmployeesQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IMapper mapper)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _mapper = mapper;
    }
    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken = default)
    {
        await using NpgsqlConnection connection = _sqlConnectionFactory.CreateConnection();

        var results = await connection.QueryAsync<EmployeeDto>(
            @"SELECT ""Guid"", ""FirstName"", ""LastName"", ""PhoneNumber"", ""JobTitleId""
                FROM ""Employees""");

        if(results is null || !results.Any())
        {
            throw new NotFoundDomainException(nameof(results));
        }

        return results.ToList();
    }

    
}