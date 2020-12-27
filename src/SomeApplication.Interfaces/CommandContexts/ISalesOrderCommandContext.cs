using SomeApplication.Interfaces.QueryObjects;

namespace SomeApplication.Interfaces.CommandContexts
{
    public interface ISalesOrderCommandContext : ICommandContext
    {
        IPriceQueryObject Prices { get; }
    }
}
