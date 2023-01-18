using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;
using EmployeeService.Domain.Exceptions.Database;
using EmployeeService.Domain.Repositories;
using EmployeeService.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Application.JobTitles.Commands.ChangeJobTitle;

public class UpdateJobTitleCommandHandler : IRequestHandler<UpdateJobTitleCommand, JobTitleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateJobTitleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<JobTitleDto> Handle(UpdateJobTitleCommand request, CancellationToken cancellationToken)
    {
        Guid jobTitleId;
        Guid.TryParse(request.Guid, out jobTitleId);

        var jobTitleResult = await _unitOfWork.JobTitleRepository.GetByIdAsync(jobTitleId);

        if (jobTitleResult is null)
        {
            throw new NotFoundDomainException(nameof(jobTitleResult));
        }

        if (!jobTitleResult.JobTitleName.Value.Equals(request.JobTitleName))
        {
            jobTitleResult.ChangeName(Name.Create(request.JobTitleName));
        }

        if (jobTitleResult.Salary.Money.Amount != request.SalaryAmount ||
            jobTitleResult.Salary.SalaryType != request.SalaryType)
        {
            jobTitleResult.ChangeSalary(Salary.Create(
                Money.Create(request.SalaryAmount, request.SalaryCurrency),
                request.SalaryType));
        }

        if (jobTitleResult.PercentageOfSales.Value != request.PercentageOfSales)
        {
            jobTitleResult.ChangePercentageOfSales(PercentageOfSales.Create(request.PercentageOfSales));
        }

        _unitOfWork.JobTitleRepository.Update(jobTitleResult);

        await _unitOfWork.SaveChangesAsync();

        jobTitleResult = await _unitOfWork.JobTitleRepository.GetByIdAsync(jobTitleResult.Guid);

        return _mapper.Map<JobTitle, JobTitleDto>(jobTitleResult);
    }
}