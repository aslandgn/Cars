using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cars.Core.EntityFramework
{
    public class Repository<T, TContext> : IRepository<T, TContext> where T : class where TContext : DbContext
    {
        private DbContext _dbContext { get; set; }
        protected DbSet<T> Entites { get => _dbContext.Set<T>(); }
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                return await _dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();

            }
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
