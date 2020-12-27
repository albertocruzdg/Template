using System;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Interfaces;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.Prices
{
    public class ChangePriceCommand : IPriceCommand
    {
        private readonly Guid productId;
        private readonly MoneyAmount newPrice;

        public ChangePriceCommand(Guid productId, MoneyAmountDTO newPrice)
        {
            this.productId = productId;
            this.newPrice = newPrice.ToMoneyAmount();
        }

        public async Task ExecuteAsync(IApplicationRepository repository, IPrices prices)
        {
            var markPriceAsExpiredCommand = new MarkPriceAsExpiredCommand(this.productId);

            await markPriceAsExpiredCommand.ExecuteAsync(repository, prices);

            var newPrice = new Price
            {
                Amount = this.newPrice,
                ProductId = this.productId
            };

            await repository.CreateAsync(newPrice);
        }
    }
}
