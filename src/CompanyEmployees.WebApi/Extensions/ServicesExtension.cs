using CompanyEmployee.RESTful.Authorization;
using CompanyEmployees.Application;
using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Application.Logger;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Shared;
using CompanyEmployees.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.RateLimiting;

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
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders(CompanyEmployeesConsts.PaginationHeader);
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

        public static void ConfigureAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ApplicationMappingProfile));

        public static void ConfigureResponseCashing(this IServiceCollection services)
            => services.AddResponseCaching();

        public static void ConfigureOutputCaching(this IServiceCollection services) 
            => services.AddOutputCache(opt =>
            {
                opt.AddPolicy(CompanyEmployeesConsts.Cach120SecondsDuration, p => p.Expire(TimeSpan.FromSeconds(120)));
            });

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            services.AddRateLimiter(opt =>
            {
                opt.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter("GlobalLimiter",
                partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 5,
                    QueueLimit = 0,
                    Window = TimeSpan.FromMinutes(1)
                }));
            });
        }

        public static void ConfigureJwt(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "CompanyImployeeApi",
                        ValidAudience = "CompanyImployeeApiUsers",
                        IssuerSigningKey = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456")),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void ConfigureHandler(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, EmployeeOrAdminHandler>();
        }
        
        public static void ConfigurePolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOrAdminPolicy", policy =>
                {
                    policy.Requirements.Add(new EmployeeOrAdminRequirement());
                });
            });
        }
    }
}
