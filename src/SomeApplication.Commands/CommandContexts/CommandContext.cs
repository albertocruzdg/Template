using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.CommandContexts
{
    internal class CommandContext : ICommandContext
    {
        public CommandContext(IApplicationRepository repository)
        {
            Repository = repository;
        }

        public IApplicationRepository Repository { get; }
    }
}
