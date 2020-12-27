using SomeApplication.Interfaces.CommandContexts;

namespace SomeApplication.Interfaces.Services
{
    public interface ISalesOrderService : ICommandService<ISalesOrderCommandContext>
    {
    }
}
