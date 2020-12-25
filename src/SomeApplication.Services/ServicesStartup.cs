using Microsoft.Extensions.DependencyInjection;
using SomeApplication.Interfaces.Services;
using SomeApplication.Services.Products;
using SomeApplication.Services.SalesOrders;

namespace SomeApplication.Services
{
    public static class ServicesStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductCreator>();
            services.AddScoped<ProductGetter>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
        }
    }
}
