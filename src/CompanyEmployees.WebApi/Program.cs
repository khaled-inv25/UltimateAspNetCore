using CompanyEmployees.Domain.Shared;
using CompanyEmployees.WebApi;
using CompanyEmployees.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.ConfigureCors();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.ConfigureLogger();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServicesManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers(config =>
{
    config.ReturnHttpNotAcceptable = true;
})
    .AddApplicationPart(typeof(CompanyEmployee.RESTful.AssemblyReference).Assembly);

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

app.UseExceptionHandler(opt => { });

app.UseHttpsRedirection();

app.UseCors(CompanyEmployeesConsts.CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
