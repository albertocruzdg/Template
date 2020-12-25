using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SomeApplication.API
{
    public class Program
    {
        private const string AppEnvPrefix = "APP_";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configBuilder =>
                {
                    configBuilder.AddEnvironmentVariables(prefix: AppEnvPrefix);
                })
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);

                    config.AddEnvironmentVariables(prefix: AppEnvPrefix);
                })
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureLogging(ConfigureSerilog);
        }

        private static void ConfigureSerilog(HostBuilderContext hostContext, ILoggingBuilder logBuilder)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(hostContext.Configuration)
                .CreateLogger();

            Log.Logger = logger;
        }
    }
}
