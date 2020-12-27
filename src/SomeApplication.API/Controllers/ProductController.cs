using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SomeApplication.Interfaces.Services;
using SomeApplication.Commands.Prices;
using SomeApplication.Commands.Products;
using SomeApplication.Interfaces.DTO;
using SomeApplication.Interfaces.QueryParameters;

namespace SomeApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IPriceService priceService;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProductService service, IPriceService priceService, ILogger<ProductsController> logger)
        {
            this.service = service;
            this.priceService = priceService;
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
            await this.service.HandleAsync(new CreateNewProductCommand(product));

            return this.Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductDTO product)
        {
            await this.service.HandleAsync(new UpdateProductCommand(id, product));

            return this.Ok();
        }

        [HttpPut("{productId:guid}/currentPrice")]
        public async Task<IActionResult> ChangePrice([FromRoute] Guid productId, [FromBody] MoneyAmountDTO newPrice)
        {
            await this.priceService.HandleAsync(new ChangePriceCommand(productId, newPrice));

            return this.Ok();
        }
    }
}
