using System;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Interfaces;
using SomeApplication.Commands.Prices;
using SomeApplication.Interfaces.Repository;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.Prices
{
    internal class PriceService : IPriceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IApplicationRepository repository;
        private readonly IPrices prices;

        public PriceService(IUnitOfWork unitOfWork, IApplicationRepository repository, IPrices prices)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.prices = prices;
        }

        public async Task ChangePrice(Guid productId, MoneyAmountDTO newPrice)
        {
            var command = new ChangePriceCommand(productId, newPrice);

            await command.ExecuteAsync(this.repository, this.prices);

            await this.unitOfWork.SaveChangesAsync();
        }
    }
}
