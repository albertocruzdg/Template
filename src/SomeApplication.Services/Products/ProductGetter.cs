using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Interfaces;
using SomeApplication.Business.Model;
using SomeApplication.Business.QueryParameters;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Services.Products
{
    internal sealed class ProductGetter
    {
        private readonly IApplicationRepository repository;
        private readonly IProducts products;
        private readonly IPrices prices;

        public ProductGetter(IApplicationRepository repository, IProducts products, IPrices prices)
        {
            this.repository = repository;
            this.products = products;
            this.prices = prices;
        }

        public Task<Product> GetAsync(Guid id) => this.repository.GetAsync<Product>(id);

        public IEnumerable<ProductDTO> Search(ProductQueryParameters parameters)
        {
            var products = parameters.Filter(this.products);

            var productPrices = this.prices
                .For(products)
                .ExcludeExpired();

            return ProductDTOFactory.Get(products, productPrices);
        }
    }
}
