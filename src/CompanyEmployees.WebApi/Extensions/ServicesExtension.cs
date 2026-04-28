using CompanyEmployees.Application;
using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Application.Logger;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Shared;
using CompanyEmployees.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.WebApi.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CompanyEmployeesConsts.CorsPolicy, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }

        public static void ConfigureLogger(this IServiceCollection services)
            => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServicesManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<CompanyEmployeeDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString(CompanyEmployeesConsts.DefaultConnection)));
    }
}
