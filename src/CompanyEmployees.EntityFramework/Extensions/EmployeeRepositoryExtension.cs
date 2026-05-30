using CompanyEmployees.Domain.Employees;
using CompanyEmployees.EntityFramework.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace CompanyEmployees.EntityFramework.Extensions
{
    public static class EmployeeRepositoryExtension
    {
        public static IQueryable<Employee> Filter(this IQueryable<Employee> employees, uint minAge, uint maxAge)
        {
            return employees.Where(e => e.Age >= minAge && e.Age <= maxAge);
        }

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return employees;
            }

            var str = search.Trim().ToLower();

            return employees.Where(e => e.Name.ToLower().Contains(str));
        }

        // To build the sort query.
        public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string? orderByQueryString)
        {
            if (string.IsNullOrEmpty(orderByQueryString))
            {
                return employees.OrderBy(e => e.Name);
            }

            var orderQuery = OrderByQueryBuilder.Build<Employee>(orderByQueryString);

            if (string.IsNullOrEmpty(orderQuery))
                return employees.OrderBy(e => e.Name);

            return employees.OrderBy(orderQuery);
        }
    }
}
