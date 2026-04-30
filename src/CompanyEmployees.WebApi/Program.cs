using CompanyEmployees.Domain.Shared;
using CompanyEmployees.WebApi;
using CompanyEmployees.WebApi.Extensions;
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

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployee.RESTful.AssemblyReference).Assembly);

var app = builder.Build();

app.UseExceptionHandler(opt => { });

app.UseHttpsRedirection();

app.UseCors(CompanyEmployeesConsts.CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
