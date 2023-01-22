using Cars.Business.Utils.Response;
using Cars.Entity.Dtos.Spesification;

namespace Cars.Business.Interfaces
{
    public interface ISpesificationService
    {
        Task<ServiceResponse<SpesificationDto>> AddSpesificationAsync(SpesificationAdd spesificationAdd);
    }
}
