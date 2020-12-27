using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Interfaces.CommandContexts
{
    public interface ICommandContext
    {
        IApplicationRepository Repository { get; }
    }
}
