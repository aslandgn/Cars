using AutoMapper;
using Cars.Business.Interfaces;
using Cars.Business.Utils.Response;
using Cars.Entity.Dtos.Spesification;

namespace Cars.Business.Concrates
{
    public class SpesificationManager : ISpesificationService
    {
        //private readonly ISpesificationDalService _spesificationDalService;
        private readonly IMapper _mapper;
        //public SpesificationManager(ISpesificationDalService spesificationDalService, IMapper mapper)
        //{
        //    _spesificationDalService = spesificationDalService;
        //    _mapper = mapper;
        //}

        public Task<ServiceResponse<SpesificationDto>> AddSpesificationAsync(SpesificationAdd spesificationAdd)
        {
            throw new NotImplementedException();
        }
    }
}
