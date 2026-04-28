using CompanyEmployees.Domain.Shared;
using CompanyEmployees.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanyEmployees.WebApi.ContextFactory
{
    public class CompenyEmployeeDbContextFactory : IDesignTimeDbContextFactory<CompanyEmployeeDbContext>
    {
        public CompanyEmployeeDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("appsettings.Development.json")
#else
                .AddJsonFile("appsettings.Production.json")
#endif
                .Build();

            var builder = new DbContextOptionsBuilder<CompanyEmployeeDbContext>()
                .UseSqlServer(configuration.GetConnectionString(CompanyEmployeesConsts.DefaultConnection),
                b => b.MigrationsAssembly("CompanyEmployees.WebApi"));

            return new CompanyEmployeeDbContext(builder.Options);
        }
    }
}
