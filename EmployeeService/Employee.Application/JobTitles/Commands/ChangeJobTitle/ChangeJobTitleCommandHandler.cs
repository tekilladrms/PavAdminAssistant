using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.ChangeJobTitle;

public class ChangeJobTitleCommandHandler : IRequestHandler<ChangeJobTitleCommand, JobTitleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChangeJobTitleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<JobTitleDto> Handle(ChangeJobTitleCommand request, CancellationToken cancellationToken)
    {
        var jobTitleResult = await _unitOfWork.JobTitleRepository.GetByIdAsync(request.JobTitleDto.Id);

        if (jobTitleResult is null)
        {
            throw new RecordsNotFoundException(nameof(jobTitleResult));
        }

        if (!jobTitleResult.JobTitleName.Value.Equals(request.JobTitleDto.JobTitleName))
        {
            jobTitleResult.ChangeName(Name.Create(request.JobTitleDto.JobTitleName));
        }

        if (jobTitleResult.Salary.Money.Amount != request.JobTitleDto.SalaryAmount ||
            jobTitleResult.Salary.SalaryType != request.JobTitleDto.SalaryType)
        {
            jobTitleResult.ChangeSalary(Salary.Create(
                Money.Create(request.JobTitleDto.SalaryAmount, request.JobTitleDto.SalaryCurrency),
                request.JobTitleDto.SalaryType));
        }

        if (jobTitleResult.PercentageOfSales.Value != request.JobTitleDto.PercentageOfSales)
        {
            jobTitleResult.ChangePercentageOfSales(PercentageOfSales.Create(request.JobTitleDto.PercentageOfSales));
        }

        _unitOfWork.JobTitleRepository.Update(jobTitleResult);

        await _unitOfWork.SaveChangesAsync();

        jobTitleResult = await _unitOfWork.JobTitleRepository.GetByIdAsync(jobTitleResult.Guid);

        return _mapper.Map<JobTitle, JobTitleDto>(jobTitleResult);
    }
}