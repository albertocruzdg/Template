using System;
using System.Threading.Tasks;
using SomeApplication.Business.Interfaces;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Services.SalesOrders
{
    public class Seller
    {
        private readonly IPrices prices;
        private readonly IApplicationRepository repository;

        public Seller(IPrices prices, IApplicationRepository repository)
        {
            this.prices = prices;
            this.repository = repository;
        }

        public async Task CreateSalesOrder(Guid[] productIds)
        {
            var productPrices = this
                .prices
                .For(productIds)
                .ExcludeExpired();

            var salesOrder = new SalesOrder(productPrices);

            await repository.CreateAsync(salesOrder);
        }
    }
}
