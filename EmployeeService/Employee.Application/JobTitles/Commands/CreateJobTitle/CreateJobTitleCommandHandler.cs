using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.CreateJobTitle;

public class CreateJobCommandHandler : IRequestHandler<CreateJobTitleCommand, JobTitleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<JobTitleDto> Handle(CreateJobTitleCommand request, CancellationToken cancellationToken)
    {
        var jobTitle = JobTitle.Create(
            Name.Create(request.JobTitleDto.JobTitleName),
            Salary.Create(
                Money.Create(request.JobTitleDto.SalaryAmount, request.JobTitleDto.SalaryCurrency),
                request.JobTitleDto.SalaryType),
            PercentageOfSales.Create(request.JobTitleDto.PercentageOfSales));

        await _unitOfWork.JobTitleRepository.AddAsync(jobTitle);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<JobTitle, JobTitleDto>(jobTitle);
    }
}