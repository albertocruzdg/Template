using SomeApplication.Interfaces.QueryObjects;

namespace SomeApplication.Interfaces.CommandContexts
{
    public interface IPriceCommandContext : ICommandContext
    {
        public IPriceQueryObject Prices { get; }
    }
}
