using System.Threading.Tasks;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Commands;

namespace SomeApplication.Interfaces.Services
{
    public interface ICommandService<T> where T : ICommandContext
    {
        Task HandleAsync(ICommand<T> command);
    }
}
