using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentValidation;
using EmployeeService.Application.Behaviors;

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
