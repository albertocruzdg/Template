using System;

namespace SomeApplication.Business.Model
{
    public class SalesOrderProduct : Entity
    {
        public Guid PriceId { get; set; }

        public Guid SalesOrderId { get; set; }

        public Price Price { get; set; }

        public Product Product => this.Price.Product;

        public int Quantity { get; set; }

        public MoneyAmount Amount => this.Price.Amount * this.Quantity;
    }
}
