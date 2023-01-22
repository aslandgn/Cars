using Cars.Core;
using Version = Cars.Entity.Entities.Version;

namespace Cars.Dal.Interfaces
{
    public interface IVersionDalService : IRepository<Version, CarContext>
    {
        Task<List<Version>> GetVersionsOfModelAsync(int modelId);
    }
}
