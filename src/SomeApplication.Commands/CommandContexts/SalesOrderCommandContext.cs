using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.QueryObjects;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.CommandContexts
{
    internal sealed class SalesOrderCommandContext : CommandContext, ISalesOrderCommandContext
    {
        public SalesOrderCommandContext(IApplicationRepository repository, IPriceQueryObject prices)
            : base(repository)
        {
            Prices = prices;
        }

        public IPriceQueryObject Prices { get; }
    }
}
