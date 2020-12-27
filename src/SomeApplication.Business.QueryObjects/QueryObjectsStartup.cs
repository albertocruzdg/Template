using Microsoft.Extensions.DependencyInjection;
using SomeApplication.Business.Collections;
using SomeApplication.Interfaces.QueryObjects;

namespace SomeApplication.Business.QueryObjects
{
    public static class QueryObjectsStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPriceQueryObject, PriceQueryObject>();
            services.AddScoped<IProductQueryObject, ProductQueryObject>();
        }
    }
}
