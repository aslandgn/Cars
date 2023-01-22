using Cars.Core;

namespace Cars.Dal.Interfaces
{
    public interface IDalService<T> : IRepository<T, CarContext> where T : class
    {
    }
}
