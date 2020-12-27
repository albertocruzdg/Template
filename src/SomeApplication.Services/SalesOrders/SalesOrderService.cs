using System.Threading.Tasks;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.CommandHandlers;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.SalesOrders
{
    internal sealed class SalesOrderService : ISalesOrderService
    {
        private readonly ICommandHandler<ISalesOrderCommandContext> commandHandler;

        public SalesOrderService(ICommandHandler<ISalesOrderCommandContext> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public Task HandleAsync(ICommand<ISalesOrderCommandContext> command) => this.commandHandler.HandleAsync(command);
    }
}
