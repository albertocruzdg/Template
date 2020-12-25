using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Repository
{
    public static class RepositoryStartup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("dbcontext") ??
                throw new InvalidOperationException("Invalid connection string");

            services.AddDbContext<DatabaseContext>((provider, options) =>
            {
                options.UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention()
                    .UseLoggerFactory(provider.GetRequiredService<ILoggerFactory>());
            });

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
