using Cars.Business.Utils.Response;
using Cars.Entity.Entities;
using System.Linq.Expressions;

namespace Cars.Business.Interfaces
{
    public interface IService<T, N> where T: BaseWithId<N>
    {
        Task<ServiceResponse<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> filter);
        Task<ServiceResponse<List<TResult>>> GetListAsync<TResult>();
        Task<ServiceResponse<TResult>> AddAsync<TAddDto,TResult>(TAddDto addDto);
        Task<ServiceResponse<TResult>> UpdateAsync<TUpdateDto, TResult>(TUpdateDto addDto);
        Task<ServiceResponse> DeleteAsync(N id);
    }
}
