using System.Collections.Generic;
using System.Linq;
using SomeApplication.Business.Model;

namespace SomeApplication.Interfaces.DTO
{
    public static class ProductDTOFactory
    {
        public static IEnumerable<ProductDTO> Get(IEnumerable<Product> products, IEnumerable<Price> prices)
        {
            foreach (var product in products)
            {
                var price = prices.FirstOrDefault(x => x.ProductId == product.Id);

                yield return Get(product, price);
            }
        }

        public static ProductDTO Get(Product product, Price price)
        {
            return new ProductDTO
            {
                Code = product.Code,
                CurrentPrice = MoneyAmountDTO.From(price?.Amount),
                Description = product.Description,
                Id = product.Id,
                Name = product.Name
            };
        }
    }
}
