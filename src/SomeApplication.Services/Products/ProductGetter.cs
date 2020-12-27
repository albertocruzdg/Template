using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.DTO;
using SomeApplication.Interfaces.QueryObjects;
using SomeApplication.Interfaces.QueryParameters;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Services.Products
{
    internal sealed class ProductGetter
    {
        private readonly IApplicationRepository repository;
        private readonly IProductQueryObject products;
        private readonly IPriceQueryObject prices;

        public ProductGetter(IApplicationRepository repository, IProductQueryObject products, IPriceQueryObject prices)
        {
            this.repository = repository;
            this.products = products;
            this.prices = prices;
        }

        public Task<Product> GetAsync(Guid id) => this.repository.GetAsync<Product>(id);

        public IEnumerable<ProductDTO> Search(ProductQueryParameters parameters)
        {
            var products = parameters.Filter(this.products).ToList();

            var productPrices = this.prices
                .For(products)
                .ExcludeExpired()
                .ToList();

            return ProductDTOFactory.Get(products, productPrices);
        }
    }
}
