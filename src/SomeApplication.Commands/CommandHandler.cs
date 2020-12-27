using System.Threading.Tasks;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.CommandHandlers;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands
{
    internal class CommandHandler<T> : ICommandHandler<T>
        where T : ICommandContext
    {
        private readonly T commandContext;
        private readonly IUnitOfWork unitOfWork;

        public CommandHandler(T commandContext, IUnitOfWork unitOfWork)
        {
            this.commandContext = commandContext;
            this.unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(ICommand<T> command)
        {
            await command.ExecuteAsync(this.commandContext);

            await this.unitOfWork.SaveChangesAsync();
        }
    }
}
