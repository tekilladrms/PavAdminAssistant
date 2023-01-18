using EmployeeService.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPiplineBehavior<,>));

        //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipilineBehavior<,>));
        services.AddAutoMapper(AssemblyReference.Assembly);
        return services;
    }
}
