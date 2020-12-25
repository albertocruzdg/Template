using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeApplication.Business.DTO;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrderService salesOrderService;

        public SalesOrdersController(ISalesOrderService salesOrderService)
        {
            this.salesOrderService = salesOrderService;
        }
        public void CreateSalesOrder(SalesOrderDTO salesOrder)
        {
            this.salesOrderService.CreateSalesOrder(salesOrder);
        }
    }
}
