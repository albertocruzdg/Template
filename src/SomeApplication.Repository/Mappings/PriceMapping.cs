using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeApplication.Business.Model;
using SomeApplication.Repository.Extensions;

namespace SomeApplication.Repository.Mappings
{
    internal class PriceMapping : IEntityTypeConfiguration<Price>
    {
        private readonly string schema;

        public PriceMapping(string schema)
        {
            this.schema = schema;
        }

        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("prices", this.schema);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            builder.OwnsOneMoneyAmount(x => x.Amount);
        }
    }
}
