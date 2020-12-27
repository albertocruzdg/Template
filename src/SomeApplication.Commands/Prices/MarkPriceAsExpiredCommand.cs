using System;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.Interfaces;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.Prices
{
    public class MarkPriceAsExpiredCommand : IPriceCommand
    {
        private readonly Guid productId;

        public MarkPriceAsExpiredCommand(Guid productId)
        {
            this.productId = productId;
        }

        public Task ExecuteAsync(IApplicationRepository repository, IPrices prices)
        {
            var currentPrice = prices
                .For(this.productId)
                .ExcludeExpired()
                .Collection
                .SingleOrDefault();

            if (currentPrice == null)
            {
                return Task.CompletedTask;
            }

            currentPrice.DueDate = DateTimeOffset.Now;

            return repository.UpdateAsync(currentPrice);
        }
    }
}
