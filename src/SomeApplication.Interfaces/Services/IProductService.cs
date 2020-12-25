using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Model;
using SomeApplication.Business.QueryParameters;

namespace SomeApplication.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> Search(ProductQueryParameters parameters);

        Task<Product> GetAsync(Guid id);

        Task Create(ProductDTO productDTO);
    }
}
