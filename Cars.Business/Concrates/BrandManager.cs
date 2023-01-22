using AutoMapper;
using Cars.Business.Interfaces;
using Cars.Business.Utils.Response;
using Cars.Dal.Interfaces;
using Cars.Entity.Dtos.Brand;
using Cars.Entity.Entities;

namespace Cars.Business.Concrates
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDalService _brandDalService;
        private readonly IMapper _mapper;
        public BrandManager(IBrandDalService brandDalService, IMapper mapper)
        {
            _brandDalService = brandDalService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BrandDto>> AddBrand(BrandAdd brandAdd)
        {
            var response = _mapper.Map<BrandDto>(await _brandDalService.AddAsync(_mapper.Map<Brand>(brandAdd)));
            return ServiceResponse<BrandDto>.Ok(response);
        }

        public async Task<ServiceResponse<BrandDto>> GetBrandAsync(int id)
        {
            var response = _mapper.Map<BrandDto>((await _brandDalService.GetListByFilterAsync(x => x.Id == id))?.FirstOrDefault());
            return ServiceResponse<BrandDto>.Ok(response);
        }

        public async Task<ServiceResponse<List<BrandDto>>> GetBrandsAsync()
        {
            var response = _mapper.Map<List<BrandDto>>(await _brandDalService.GetListByFilterAsync());
            return ServiceResponse<List<BrandDto>>.Ok(response);
        }
    }
}
