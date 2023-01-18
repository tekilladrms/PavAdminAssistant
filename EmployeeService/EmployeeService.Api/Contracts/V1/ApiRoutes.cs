namespace EmployeeService.Api.Contracts.V1;

public static class ApiRoutes
{
    public const string Root = "Api";
    public const string Version = "v1";
    public const string Base = Root + "/" + Version;

    public static class Employees
    {
        public const string GetAll = Base + "/employees";
        public const string Create = Base + "/employees";
        public const string Update = Base + "/employees/{employeeId}";
        public const string GetById = Base + "/employees/{employeeId}";
        public const string GetBySpec = Base + "/employees/{employeeId}";
        public const string Delete = Base + "/employees/{employeeId}";

        public const string GetAllByJobTitleId = Base + "/employees/jobTitle={jobTitleId}";
        public const string SetJobTitleIdToEmployee = Base + "/employees/{employeeId}/jobTitle";
    }

    public static class JobTitles
    {
        public const string GetAll = Base + "/jobTitles";
        public const string Create = Base + "/jobTitles";
        public const string Update = Base + "/jobTitles/{jobTitleId}";
        public const string GetById = Base + "/jobTitles/{jobTitleId}";
        public const string Delete = Base + "/jobTitles/{jobTitleId}";
    }
}
