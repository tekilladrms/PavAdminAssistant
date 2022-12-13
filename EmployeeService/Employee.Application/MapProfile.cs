using AutoMapper;
using EmployeeService.Application.DTO;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application;

public class MapProfile : Profile
{
	public MapProfile()
	{
		CreateMap<Employee, EmployeeDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Guid))
			.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
			.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
			.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value));

		CreateMap<JobTitle, JobTitleDto>()
			.ForMember(dest => dest.SalaryType, opt => opt.MapFrom(src => src.Salary.SalaryType))
			.ForMember(dest => dest.SalaryAmount, opt => opt.MapFrom(src => src.Salary.Money.Amount))
			.ForMember(dest => dest.SalaryCurrency, opt => opt.MapFrom(src => src.Salary.Money.Currency))
			.ForMember(dest => dest.PercentageOfSales, opt => opt.MapFrom(src => src.PercentageOfSales.Value));
		
	}
}