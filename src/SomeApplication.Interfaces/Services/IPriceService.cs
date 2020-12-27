using SomeApplication.Interfaces.CommandContexts;

namespace SomeApplication.Interfaces.Services
{
    public interface IPriceService : ICommandService<IPriceCommandContext>
    {
    }
}
