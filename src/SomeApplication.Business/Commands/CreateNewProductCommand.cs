using SomeApplication.Business.DTO;
using SomeApplication.Business.Model;

namespace SomeApplication.Business.Commands
{
    public class CreateNewProductCommand
    {
        public CreateNewProductCommand(ProductDTO dto)
        {
            this.Product = new Product
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
            };

            this.CurrentPrice = dto.CurrentPrice.ToMoneyAmount();
        }

        public Product Product { get; }

        public MoneyAmount CurrentPrice { get; }
    }
}
