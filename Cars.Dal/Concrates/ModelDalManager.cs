using Cars.Core.EntityFramework;
using Cars.Dal.Interfaces;
using Cars.Entity.Entities;

namespace Cars.Dal.Concrates
{
    public class ModelDalManager : Repository<Model, CarContext>, IModelDalService
    {
        public ModelDalManager(CarContext dbContext) : base(dbContext)
        {
        }
    }
}
