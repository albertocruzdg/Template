using System.Threading.Tasks;

namespace SomeApplication.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
