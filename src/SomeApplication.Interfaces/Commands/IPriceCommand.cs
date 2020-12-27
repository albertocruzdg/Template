using System.Threading.Tasks;
using SomeApplication.Business.Interfaces;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Interfaces.Commands
{
    public interface IPriceCommand
    {
        Task ExecuteAsync(IApplicationRepository repository, IPrices prices);
    }
}
