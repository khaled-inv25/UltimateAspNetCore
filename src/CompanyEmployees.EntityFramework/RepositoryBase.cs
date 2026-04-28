using CompanyEmployees.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyEmployees.EntityFramework
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected  CompanyEmployeeDbContext DbContext;

        public RepositoryBase(CompanyEmployeeDbContext dbContext) => DbContext = dbContext;

        public IQueryable<T> FindAll(bool trackChanges)
            => !trackChanges ? DbContext.Set<T>().AsNoTracking() : DbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
            => !trackChanges ? DbContext.Set<T>().Where(expression).AsNoTracking() : DbContext.Set<T>().Where(expression);

        public async Task CreateAsync(T entity) => await DbContext.Set<T>().AddAsync(entity);

        public void Delete(T entity) => DbContext.Remove(entity);

        public void Update(T entity) => DbContext.Update(entity);
    }
}
