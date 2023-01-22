using Cars.Business.Utils.Response;
using Cars.Entity.Dtos.Version;

namespace Cars.Business.Interfaces
{
    public interface IVersionService
    {
        Task<ServiceResponse<List<VersionDto>>> GetVersionsOfModelAsync(int modelId);
    }
}
