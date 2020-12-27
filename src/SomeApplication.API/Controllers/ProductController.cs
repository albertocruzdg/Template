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
        private readonly IProductService productService;
        private readonly IPriceService priceService;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProductService productService, IPriceService priceService, ILogger<ProductsController> logger)
        {
            this.productService = productService;
            this.priceService = priceService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll([FromQuery] ProductQueryParameters query)
        {
            return await this.productService.Search(query);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var product = await this.productService.GetAsync(id);

            return this.Ok(product);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            await this.productService.Create(product);

            return this.Ok();
        }

        [HttpPut("{productId:guid}/currentPrice")]
        public async Task<IActionResult> ChangePrice([FromRoute] Guid productId, [FromBody] MoneyAmountDTO newPrice)
        {
            await this.priceService.ChangePrice(productId, newPrice);

            return this.Ok();
        }
    }
}
