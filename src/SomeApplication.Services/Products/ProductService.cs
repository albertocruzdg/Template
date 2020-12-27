using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.CommandHandlers;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.DTO;
using SomeApplication.Interfaces.QueryParameters;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.Products
{
    internal class ProductService : IProductService
    {
        private readonly ICommandHandler<IProductCommandContext> commandHandler;
        private readonly ProductGetter getter;

        public ProductService(ICommandHandler<IProductCommandContext> commandHandler, ProductGetter getter)
        {
            this.commandHandler = commandHandler;
            this.getter = getter;
        }

        public Task HandleAsync(ICommand<IProductCommandContext> command)
            => this.commandHandler.HandleAsync(command);

        public Task<Product> GetAsync(Guid id) => this.getter.GetAsync(id);

        public Task<IEnumerable<ProductDTO>> Search(ProductQueryParameters parameters) => 
            Task.Run(() => this.getter.Search(parameters));
    }
}
