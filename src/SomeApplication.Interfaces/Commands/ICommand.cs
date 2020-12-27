using System.Threading.Tasks;
using SomeApplication.Interfaces.CommandContexts;

namespace SomeApplication.Interfaces.Commands
{
    public interface ICommand<T>
        where T : ICommandContext
    {
        Task ExecuteAsync(T context);
    }
}
