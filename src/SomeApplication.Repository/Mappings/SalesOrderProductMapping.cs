﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeApplication.Business.Model;
using SomeApplication.Repository.Extensions;

namespace SomeApplication.Repository.Mappings
{
    internal class SalesOrderProductMapping : IEntityTypeConfiguration<SalesOrderProduct>
    {
        private readonly string schema;

        public SalesOrderProductMapping(string schema)
        {
            this.schema = schema;
        }

        public void Configure(EntityTypeBuilder<SalesOrderProduct> builder)
        {
            builder.ToTable("sales_order_products", this.schema);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Price).WithMany().HasForeignKey(x => x.PriceId);
            builder.OwnsOneMoneyAmount(x => x.Amount);
        }
    }
}
