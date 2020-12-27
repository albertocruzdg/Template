using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.DTO;

namespace SomeApplication.Commands.SalesOrders
{
    public class CreateSalesOrderCommand : ICommand<ISalesOrderCommandContext>
    {
        private readonly IEnumerable<SalesOrderProductDTO> dto;

        public CreateSalesOrderCommand(SalesOrderDTO dto)
        {
            this.dto = dto.Products;
        }

        public async Task ExecuteAsync(ISalesOrderCommandContext context)
        {
            var order = new SalesOrder
            {
                Detail = context
                    .Prices
                    .For(dto.Select(x => x.ProductId))
                    .ExcludeExpired()
                    .Select(x => new SalesOrderProduct
                    {
                        Price = x,
                        Quantity = dto.Where(x => x.ProductId == x.ProductId).Sum(x => x.Quantity)
                    })
                    .ToList()
            };

            await context.Repository.CreateAsync(order);
        }
    }
}
