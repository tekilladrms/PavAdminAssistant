using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.CreateJobTitle;

public class CreateJobCommandHandler : IRequestHandler<CreateJobTitleCommand, JobTitleDto>
{
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateJobCommandHandler(IUnitOfWork unitOfWork, IJobTitleRepository jobTitleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _jobTitleRepository = jobTitleRepository;
        _mapper = mapper;
    }
    public async Task<JobTitleDto> Handle(CreateJobTitleCommand request, CancellationToken cancellationToken)
    {
        var jobTitleNameResult = Name.Create(request.JobTitleDto.JobTitleName);

        var salaryResult = Salary.Create(
            Money.Create(request.JobTitleDto.SalaryAmount, request.JobTitleDto.SalaryCurrency), 
            request.JobTitleDto.SalaryType);

        var percentageOfSalesResult = PercentageOfSales.Create(request.JobTitleDto.PercentageOfSales);

        var jobTitle = JobTitle.Create(
            Guid.NewGuid(),
            jobTitleNameResult,
            salaryResult,
            percentageOfSalesResult);

        await _jobTitleRepository.AddAsync(jobTitle);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<JobTitle, JobTitleDto>(jobTitle);
    }
}