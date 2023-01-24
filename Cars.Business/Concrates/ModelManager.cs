using AutoMapper;
using Cars.Business.Interfaces;
using Cars.Business.Utils.Response;
using Cars.Dal.Interfaces;
using Cars.Entity.Dtos.Model;
using Cars.Entity.Entities;

namespace Cars.Business.Concrates
{
    public class ModelManager : IModelService
    {
        private readonly IModelDalService _modelDalService;
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public ModelManager(IMapper mapper, IModelDalService modelDalService, IBrandService brandService)
        {
            _mapper = mapper;
            _modelDalService = modelDalService;
            _brandService = brandService;
        }

        public async Task<ServiceResponse<ModelDto>> AddModelAsync(ModelAdd modelDto)
        {
            if (modelDto.BrandId <= 0)
            {
                return ServiceResponse<ModelDto>.BadRequest("Marka bilgisi boş olamaz");
            }
            var dbModel = await _modelDalService.GetListByFilterAsync(x => x.Code.Equals(modelDto.Code));
            if (dbModel.Count > 0)
            {
                return ServiceResponse<ModelDto>.BadRequest("Aynı modelde araç eklenemez");
            }
            var dbBrand = await _brandService.GetBrandAsync(modelDto.BrandId);
            if (dbBrand.Data == null)
            {
                return ServiceResponse<ModelDto>.NotFound("Marka bilgisi bulunamadı");
            }
            var model = _mapper.Map<ModelDto>(await _modelDalService.AddAsync(_mapper.Map<Model>(modelDto)));

            return ServiceResponse<ModelDto>.Ok(model);
        }

        public async Task<ServiceResponse<List<ModelDto>>> GetModelsOfBrandAsync(int brandId)
        {
            if (brandId <= 0)
            {
                return ServiceResponse<List<ModelDto>>.BadRequest("Marka bilgisi boş olamaz");
            }

            var models = await _modelDalService.GetListByFilterAsync(x => x.BrandId == brandId && x.IsActive == true && x.IsDeleted == false);
            var modelDtos = _mapper.Map<List<ModelDto>>(models);
            return ServiceResponse<List<ModelDto>>.Ok(modelDtos);
        }
    }
}
