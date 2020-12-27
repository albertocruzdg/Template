using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.DTO;
using SomeApplication.Interfaces.QueryParameters;

namespace SomeApplication.Interfaces.Services
{
    public interface IProductService : ICommandService<IProductCommandContext>
    {
        Task<IEnumerable<ProductDTO>> Search(ProductQueryParameters parameters);

        Task<Product> GetAsync(Guid id);
    }
}
