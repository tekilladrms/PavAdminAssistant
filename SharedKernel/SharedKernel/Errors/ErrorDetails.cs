using System.Text.Json;

namespace EmployeeService.SharedKernel.Errors
{
    public class ErrorDetails
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
