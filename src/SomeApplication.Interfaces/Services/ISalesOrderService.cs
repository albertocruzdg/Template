using System.Threading.Tasks;
using SomeApplication.Business.DTO;

namespace SomeApplication.Interfaces.Services
{
    public interface ISalesOrderService
    {
        Task CreateSalesOrder(SalesOrderDTO salesOrderDTO);
    }
}
