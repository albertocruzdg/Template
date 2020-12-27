using Microsoft.Extensions.DependencyInjection;
using SomeApplication.Interfaces.Services;
using SomeApplication.Services.Prices;
using SomeApplication.Services.Products;

namespace SomeApplication.Services
{
    public static class ServicesStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductGetter>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPriceService, PriceService>();
        }
    }
}
