using System.Threading.Tasks;
using SomeApplication.Business.Commands;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Services.Products
{
    internal sealed class ProductCreator
    {
        private readonly IApplicationRepository repository;

        public ProductCreator(IApplicationRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(CreateNewProductCommand command)
        {
            var price = new Price
            {
                Amount = command.CurrentPrice,
                Product = command.Product,
            };

            await this.repository.CreateAsync(command.Product);
            await this.repository.CreateAsync(price);
        }
    }
}
