using AutoMapper;
using Dapper;
using EmployeeService.Application.Abstractions;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Exceptions.Database;
using MediatR;
using Npgsql;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.Employees.Queries.GetEmployeeById;
public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMapper _mapper;

	public GetEmployeeByIdQueryHandler(ISqlConnectionFactory connectionFactory, IMapper mapper)
    {
        _sqlConnectionFactory = connectionFactory;
        _mapper = mapper;
    }
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken = default)
    {
        Guid EmployeeId;
        Guid.TryParse(request.EmployeeId, out EmployeeId);

        await using NpgsqlConnection connection = _sqlConnectionFactory.CreateConnection();

        EmployeeDto resultDto = await connection.QueryFirstOrDefaultAsync<EmployeeDto>(
            @"SELECT ""Guid"", ""FirstName"", ""LastName"", ""PhoneNumber"", ""JobTitleId""
                FROM ""Employees""
                WHERE ""Guid"" = @EmployeeId",
            new
            {
                EmployeeId,
            });

        if (resultDto is null)
        {
            throw new NotFoundDomainException($"Not found record with id: {request.EmployeeId}");
        }

        return resultDto;
    }
}