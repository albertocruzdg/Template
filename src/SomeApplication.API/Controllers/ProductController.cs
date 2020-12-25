using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SomeApplication.Business.DTO;
using SomeApplication.Business.QueryParameters;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll([FromQuery] ProductQueryParameters query)
        {
            return await this.service.Search(query);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var product = await this.service.GetAsync(id);

            return this.Ok(product);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            await this.service.Create(product);

            return this.Ok();
        }
    }
}
