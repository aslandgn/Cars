using Cars.Core;
using Cars.Entity.Entities;

namespace Cars.Dal.Interfaces
{
    public interface IBrandDalService : IRepository<Brand, CarContext>
    {
    }
}
