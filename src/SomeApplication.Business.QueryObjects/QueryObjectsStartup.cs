using Microsoft.Extensions.DependencyInjection;
using SomeApplication.Business.Collections;
using SomeApplication.Business.Interfaces;

namespace SomeApplication.Business.QueryObjects
{
    public static class QueryObjectsStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPrices, PriceQueryObject>();
            services.AddTransient<IProducts, ProductQueryObject>();
        }
    }
}
