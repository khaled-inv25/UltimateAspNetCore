using CompanyEmployees.Domain.Companies;
using CompanyEmployees.Domain.Employees;
using CompanyEmployees.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.EntityFramework
{
    public class CompanyEmployeeDbContext : DbContext
    {
        public CompanyEmployeeDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyDataSeeder());
            modelBuilder.ApplyConfiguration(new EmployeeDataSeeder());
        }
    }
}
