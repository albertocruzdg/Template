using System;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.DTO;

namespace SomeApplication.Commands.Prices
{
    public class ChangePriceCommand : ICommand<IPriceCommandContext>
    {
        private readonly Guid productId;
        private readonly MoneyAmount newPrice;

        public ChangePriceCommand(Guid productId, MoneyAmountDTO newPrice)
            : this(productId, newPrice.ToMoneyAmount())
        {
        }

        public ChangePriceCommand(Guid productId, MoneyAmount newPrice)
        {
            this.productId = productId;
            this.newPrice = newPrice;
        }

        public async Task ExecuteAsync(IPriceCommandContext context)
        {
            var price = context
                .Prices
                .For(this.productId)
                .ExcludeExpired()
                .SingleOrDefault();

            if (price.Amount == this.newPrice)
            {
                return;
            }

            if (price != null)
            {
                price.MarkAsExpired();
                await context.Repository.UpdateAsync(price);
            }

            var newPrice = new Price
            {
                Amount = this.newPrice,
                ProductId = this.productId
            };

            await context.Repository.CreateAsync(newPrice);
        }
    }
}
