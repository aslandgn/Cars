using Cars.Core.EntityFramework;
using Cars.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Version = Cars.Entity.Entities.Version;

namespace Cars.Dal.Concrates
{
    public class VersionDalManager : Repository<Version, CarContext>, IVersionDalService
    {
        public VersionDalManager(CarContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Version>> GetVersionsOfModelAsync(int modelId)
        {
            return await Entites.Include(x => x.TransmissionType).Where(x => x.ModelId == modelId && x.IsActive && !x.IsDeleted).ToListAsync();
        }
    }
}
