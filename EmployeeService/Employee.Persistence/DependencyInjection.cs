using EmployeeService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IJobTitleRepository, JobTitleRepository>();

            return services;
        }
    }
}
