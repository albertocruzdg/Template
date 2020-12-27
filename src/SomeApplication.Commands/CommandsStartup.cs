using Microsoft.Extensions.DependencyInjection;
using SomeApplication.Commands.CommandContexts;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.CommandHandlers;

namespace SomeApplication.Commands
{
    public static class CommandsStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(ICommandHandler<>), typeof(CommandHandler<>));

            services.AddScoped<IPriceCommandContext, PriceCommandContext>();
            services.AddScoped<IProductCommandContext, ProductCommandContext>();
            services.AddScoped<ISalesOrderCommandContext, SalesOrderCommandContext>();
        }
    }
}
