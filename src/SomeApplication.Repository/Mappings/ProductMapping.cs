using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeApplication.Business.Model;

namespace SomeApplication.Repository.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        private readonly string schema;

        public ProductMapping(string schema)
        {
            this.schema = schema;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", schema);
            builder.HasKey(x => x.Id).HasName("pk_products");

            builder.Property(x => x.Code);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
        }
    }
}
