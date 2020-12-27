using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Commands.Products
{
    public class CreateNewProductCommand
    {
        private readonly Product product;
        private readonly Price price;

        public CreateNewProductCommand(ProductDTO dto)
        {
            this.product = new Product
            {
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

        public async Task HandleAsync(IApplicationRepository repository)
        {
            await repository.CreateAsync(this.product);
            await repository.CreateAsync(this.price);
        }
    }
}
