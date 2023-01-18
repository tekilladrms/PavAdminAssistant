using System;

namespace EmployeeService.Application.DTO;

public class EmployeeDto
{
    public Guid Guid { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
    public Guid JobTitleId { get; set; }
}