using System.Threading.Tasks;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.CommandHandlers;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.Prices
{
    internal sealed class PriceService : IPriceService
    {
        private readonly ICommandHandler<IPriceCommandContext> commandHandler;

        public PriceService(ICommandHandler<IPriceCommandContext> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public Task HandleAsync(ICommand<IPriceCommandContext> command) => this.commandHandler.HandleAsync(command);
    }
}
