using EmployeeService.Application;
using EmployeeService.Domain.Repositories;
using EmployeeService.Persistence;
using EmployeeService.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddMediatR(AssemblyReference.Assembly);
builder.Services.AddAutoMapper(AssemblyReference.Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IJobTitleRepository, JobTitleRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql("Host=localhost;Port=5432;Database=employeesDb;Username=postgres;Password=fedurin88"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
