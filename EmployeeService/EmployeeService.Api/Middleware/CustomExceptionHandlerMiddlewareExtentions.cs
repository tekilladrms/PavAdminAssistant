using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;

namespace EmployeeService.Api.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
