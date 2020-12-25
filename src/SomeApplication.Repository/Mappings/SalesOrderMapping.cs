using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeApplication.Business.Model;

namespace SomeApplication.Repository.Mappings
{
    internal class SalesOrderMapping : IEntityTypeConfiguration<SalesOrder>
    {
        private readonly string schema;

        public SalesOrderMapping(string schema)
        {
            this.schema = schema;
        }

        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.ToTable("sales_orders", this.schema);
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Detail).WithOne();
        }
    }
}
