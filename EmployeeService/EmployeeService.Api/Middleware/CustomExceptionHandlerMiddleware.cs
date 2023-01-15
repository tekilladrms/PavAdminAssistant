﻿using EmployeeService.Domain.Errors;
using EmployeeService.Domain.Exceptions;
using EmployeeService.Domain.Exceptions.Database;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeService.Api.Middleware;

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
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            DomainException => "Domain error",
            ValidationException => "Validation error",
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
        return result;
    }
}
