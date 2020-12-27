using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.CommandContexts
{
    internal sealed class ProductCommandContext : IProductCommandContext
    {
        public ProductCommandContext(IApplicationRepository repository, PriceCommandContext priceContext)
        {
            Repository = repository;
            PriceContext = priceContext;
        }

        public IApplicationRepository Repository { get; }
        
        public IPriceCommandContext PriceContext { get; }
    }
}
