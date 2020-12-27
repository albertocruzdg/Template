using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.QueryObjects;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.CommandContexts
{
    internal sealed class PriceCommandContext : IPriceCommandContext
    {
        public PriceCommandContext(IApplicationRepository repository, IPriceQueryObject prices)
        {
            this.Repository = repository;
            this.Prices = prices;
        }

        public IApplicationRepository Repository { get; }
        
        public IPriceQueryObject Prices { get; }
    }
}
