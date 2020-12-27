using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeApplication.Commands.SalesOrders;
using SomeApplication.Interfaces.DTO;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrderService service;

        public SalesOrdersController(ISalesOrderService service)
        {
            this.service = service;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> CreateSalesOrder(SalesOrderDTO salesOrder)
        {
            await this.service.HandleAsync(new CreateSalesOrderCommand(salesOrder));

            return this.Ok();
        }
    }
}
