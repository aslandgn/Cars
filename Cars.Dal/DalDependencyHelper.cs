using Cars.Core;
using Cars.Core.EntityFramework;
using Cars.Dal.Concrates;
using Cars.Dal.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Dal
{
    public static class DalDependencyHelper
    {
        public static void ConfigureDalServices(this IServiceCollection service)
        {
            service.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            service.AddTransient(typeof(IDalService<>), typeof(DalManager<>));
            service.AddTransient<IBrandDalService, BrandDalManager>();
            service.AddTransient<IModelDalService, ModelDalManager>();
            service.AddTransient<IVersionDalService, VersionDalManager>();
        }
    }
}
