using Cars.Business.Utils.Response;
using Cars.Entity.Dtos.Model;

namespace Cars.Business.Interfaces
{
    public interface IModelService
    {
        Task<ServiceResponse<ModelDto>> AddModelAsync(ModelAdd modelDto);
        Task<ServiceResponse<List<ModelDto>>> GetModelsOfBrandAsync(int brandId);
    }
}
