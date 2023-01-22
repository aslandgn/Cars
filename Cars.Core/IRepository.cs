using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cars.Core
{
    public interface IRepository<T, TContext> where T : class 
    {
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> expression = null);

    }
}