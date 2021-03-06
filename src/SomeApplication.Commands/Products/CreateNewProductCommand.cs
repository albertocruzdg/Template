﻿using System.Threading.Tasks;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.CommandContexts;
using SomeApplication.Interfaces.Commands;
using SomeApplication.Interfaces.DTO;

namespace SomeApplication.Commands.Products
{
    public class CreateNewProductCommand : ICommand<IProductCommandContext>
    {
        private readonly Product product;
        private readonly Price price;

        public CreateNewProductCommand(ProductDTO dto)
        {
            this.product = new Product
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
            };

            this.price = new Price
            {
                Amount = dto.CurrentPrice.ToMoneyAmount(),
                Product = this.product
            };
        }

        public async Task ExecuteAsync(IProductCommandContext context)
        {
            await context.Repository.CreateAsync(this.product);
            await context.Repository.CreateAsync(this.price);
        }
    }
}
