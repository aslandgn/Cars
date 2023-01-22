using Cars.Business.Concrates;
using Cars.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Business
{
    public static class BusinessDependencyHelper
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IModelService, ModelManager>();
            services.AddScoped<IVersionService, VersionManager>();
            services.AddScoped(typeof(IService<,>), typeof(Manager<,>));
        }
    }
}