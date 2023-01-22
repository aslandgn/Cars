using Cars.Core.EntityFramework;
using Cars.Dal.Interfaces;
using Cars.Entity.Entities;

namespace Cars.Dal.Concrates
{
    public class BrandDalManager : Repository<Brand, CarContext>, IBrandDalService 
    {
        public BrandDalManager(CarContext dbContext) : base(dbContext)
        {
        }
    }
}
