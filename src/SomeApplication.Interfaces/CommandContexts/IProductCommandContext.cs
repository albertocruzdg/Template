namespace SomeApplication.Interfaces.CommandContexts
{
    public interface IProductCommandContext : ICommandContext
    {
        public IPriceCommandContext PriceContext { get; }
    }
}
