using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SomeApplication.Business.Commands;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Model;
using SomeApplication.Business.QueryParameters;
using SomeApplication.Interfaces.Repository;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.Products
{
    internal class ProductService : IProductService
    {
        private readonly ProductGetter getter;
        private readonly ProductCreator creator;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(ProductGetter getter, ProductCreator creator, IUnitOfWork unitOfWork)
        {
            this.getter = getter;
            this.creator = creator;
            this.unitOfWork = unitOfWork;
        }

        public Task<Product> GetAsync(Guid id) => this.getter.GetAsync(id);

        public async Task Create(ProductDTO productDTO)
        {
            var command = new CreateNewProductCommand(productDTO);

            await this.creator.HandleAsync(command);

            await this.unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<ProductDTO>> Search(ProductQueryParameters parameters) => 
            Task.Run(() => this.getter.Search(parameters));
    }
}
