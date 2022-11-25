using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application;

public class MapProfile : Profile
{
	public MapProfile()
	{
		CreateMap<Employee, EmployeeDto>();

		CreateMap<JobTitle, JobTitleDto>()
			.ForMember(dest => dest.SalaryType, opt => opt.MapFrom(src => src.Salary.SalaryType))
			.ForMember(dest => dest.SalaryAmount, opt => opt.MapFrom(src => src.Salary.Money.Amount))
			.ForMember(dest => dest.SalaryCurrency, opt => opt.MapFrom(src => src.Salary.Money.Currency));
	}
}