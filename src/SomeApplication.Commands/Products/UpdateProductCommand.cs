using System;
using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Commands.Prices;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.DTO;

namespace SomeApplication.Commands.Products
{
    public class UpdateProductCommand : ICommand<IProductCommandContext>
    {
        private readonly Product product;
        private readonly Price price;

        public UpdateProductCommand(Guid productId, ProductDTO dto)
        {
            this.product = new Product
            {
                Id = productId,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
            };

            this.price = new Price
            {
                Amount = dto.CurrentPrice.ToMoneyAmount(),
                Product = this.product
            };
        }

        public async Task ExecuteAsync(IProductCommandContext context)
        {
            await context.Repository.UpdateAsync(product);

            await new ChangePriceCommand(this.product.Id, this.price.Amount)
                .ExecuteAsync(context.PriceContext);
        }
    }
}
