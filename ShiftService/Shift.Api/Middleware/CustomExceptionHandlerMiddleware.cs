using EmployeeService.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using SharedKernel.Errors;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShiftService.Api.Middleware;

public class CustomExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {

            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var response = new
        {
            title = GetTitle(exception),
            status = statusCode,
            errors = GetErrors(exception)
        };


        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            BadHttpRequestException => StatusCodes.Status400BadRequest,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            DbException => StatusCodes.Status501NotImplemented,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            DomainException => "Domain error",
            ValidationException => "Validation error",
            DbException => "Database error",
            _ => "Server Error"

        };

    private static IReadOnlyCollection<ErrorDetails> GetErrors(Exception exception)
    {
        var result = new List<ErrorDetails>();

        if (exception is ValidationException validationException)
        {
            foreach (var err in validationException.Errors)
            {
                result.Add(new ErrorDetails
                {
                    Title = err.PropertyName,
                    Message = err.ErrorMessage
                });
            }
        }

        if (exception is DbException dbException)
        {
            result.Add( new ErrorDetails
            {
                Title = "DbError",
                Message = dbException.Message
            });
        }
        return result;
    }
}
