using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.ChangeJobTitle;

public class ChangeJobTitleCommandHandler : IRequestHandler<ChangeJobTitleCommand, JobTitleDto>
{
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChangeJobTitleCommandHandler(IUnitOfWork unitOfWork, IJobTitleRepository jobTitleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _jobTitleRepository = jobTitleRepository;
        _mapper = mapper;
    }
    public async Task<JobTitleDto> Handle(ChangeJobTitleCommand request, CancellationToken cancellationToken)
    {
        var jobTitleResult = await _jobTitleRepository.GetByIdAsync(request.id);

        if (jobTitleResult is null)
        {
            throw new RecordsNotFoundException(nameof(jobTitleResult));
        }

        if (!jobTitleResult.JobTitleName.Value.Equals(request.jobTitleDto.JobTitleName))
        {
            jobTitleResult.ChangeName(Name.Create(request.jobTitleDto.JobTitleName));
        }

        if(jobTitleResult.Salary.Money.Amount != request.jobTitleDto.SalaryAmount || 
            jobTitleResult.Salary.SalaryType != request.jobTitleDto.SalaryType)
        {
            jobTitleResult.ChangeSalary(Salary.Create(
                Money.Create(request.jobTitleDto.SalaryAmount, request.jobTitleDto.SalaryCurrency), 
                request.jobTitleDto.SalaryType));
        }

        if(jobTitleResult.PercentageOfSales.Value != request.jobTitleDto.PercentageOfSales)
        {
            jobTitleResult.ChangePercentageOfSales(PercentageOfSales.Create(request.jobTitleDto.PercentageOfSales));
        }

        _jobTitleRepository.Update(jobTitleResult);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<JobTitle, JobTitleDto>(jobTitleResult);
    }
}