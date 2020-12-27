using System.Threading.Tasks;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Commands;

namespace SomeApplication.Interfaces.CommandHandlers
{
    public interface ICommandHandler<T>
        where T : ICommandContext
    {
        Task HandleAsync(ICommand<T> command);
    }
}
