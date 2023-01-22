using Cars.Business.Utils.Response;
using Cars.Entity.Dtos.Brand;

namespace Cars.Business.Interfaces
{
    public interface IBrandService
    {
        Task<ServiceResponse<BrandDto>> AddBrand(BrandAdd brandAdd);
        Task<ServiceResponse<BrandDto>> GetBrandAsync(int id);
        Task<ServiceResponse<List<BrandDto>>> GetBrandsAsync();
    }
}
