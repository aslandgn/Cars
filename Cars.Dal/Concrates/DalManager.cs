using Cars.Core.EntityFramework;
using Cars.Dal.Interfaces;

namespace Cars.Dal.Concrates
{
    public class DalManager<T> : Repository<T, CarContext>, IDalService<T> where T : class
    {
        public DalManager(CarContext dbContext) : base(dbContext)
        {
        }
    }
}
