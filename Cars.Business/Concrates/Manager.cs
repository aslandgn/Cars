using AutoMapper;
using Cars.Business.Interfaces;
using Cars.Business.Utils.Response;
using Cars.Dal.Interfaces;
using Cars.Entity.Entities;
using System.Linq.Expressions;

namespace Cars.Business.Concrates
{
    public class Manager<T, N> : IService<T, N> where T : BaseWithId<N>
    {
        private readonly IDalService<T> _dalService;
        private readonly IMapper _mapper;

        public Manager(IDalService<T> dalService, IMapper mapper)
        {
            _mapper = mapper;
            _dalService = dalService;
        }
        public async Task<ServiceResponse<TResult>> AddAsync<TAddDto, TResult>(TAddDto addDto)
        {
            var response = _mapper.Map<TResult>(await _dalService.AddAsync(_mapper.Map<T>(addDto)));
            return ServiceResponse<TResult>.Ok(response);
        }

        public async Task<ServiceResponse> DeleteAsync(N id)
        {
            var entity = (await _dalService.GetListByFilterAsync(x => x.Id.Equals(id))).FirstOrDefault();
            entity.IsDeleted = true;
            await _dalService.Update(entity);
            return new ServiceResponse().Ok();
        }

        public async Task<ServiceResponse<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> filter)
        {
            var response = _mapper.Map<TResult>((await _dalService.GetListByFilterAsync(filter)).FirstOrDefault());
            return ServiceResponse<TResult>.Ok(response);
        }

        public async Task<ServiceResponse<List<TResult>>> GetListAsync<TResult>()
        {
            var response = _mapper.Map<List<TResult>>(await _dalService.GetListByFilterAsync(x => x.IsActive && !x.IsDeleted));
            return ServiceResponse<List<TResult>>.Ok(response);
        }

        public async Task<ServiceResponse<TResult>> UpdateAsync<TUpdateDto, TResult>(TUpdateDto addDto)
        {
            var response = _mapper.Map<TResult>(await _dalService.Update(_mapper.Map<T>(addDto)));
            return ServiceResponse<TResult>.Ok(response);
        }
    }
}
