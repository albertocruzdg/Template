using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;
        private readonly ILogger<UnitOfWork> logger;

        public UnitOfWork(DatabaseContext context, ILogger<UnitOfWork> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();

            this.logger.LogInformation($"Calling SaveChanges on dbcontext with ContextId = {this.context.ContextId}");
        }
    }
}
