using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace SomeApplication.Data.Upgrader
{
    class Program
    {
        static int Main(string[] args)
        {
            //TODO: Move to appsettings.json
            var connectionString = args.FirstOrDefault() ??
                "Server=localhost;Port=5432;Database=SomeApplication;User Id=postgres;Password=postgres;timeout=3";

            var upgrader = DeployChanges
                .To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithTransaction()
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.WriteLine(result.Error);
                return -1;
            }

            Console.WriteLine("Success!");
            return 0;
        }
    }
}
