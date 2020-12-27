using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Model;
using SomeApplication.Business.QueryParameters;
using SomeApplication.Commands.Products;
using SomeApplication.Interfaces.Repository;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.Products
{
    internal class ProductService : IProductService
    {
        private readonly ProductGetter getter;
        private readonly IApplicationRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(ProductGetter getter, IApplicationRepository repository, IUnitOfWork unitOfWork)
        {
            this.getter = getter;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public Task<Product> GetAsync(Guid id) => this.getter.GetAsync(id);

        public async Task Create(ProductDTO productDTO)
        {
            var command = new CreateNewProductCommand(productDTO);

            await command.HandleAsync(repository);

            await this.unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<ProductDTO>> Search(ProductQueryParameters parameters) => 
            Task.Run(() => this.getter.Search(parameters));
    }
}
