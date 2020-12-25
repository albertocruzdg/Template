using System;

namespace SomeApplication.Business.Model
{
    public class SalesOrderProduct : Entity
    {
        public SalesOrderProduct(Price price)
        {
            this.Price = price;
            this.Amount = price.Amount;
        }

        private SalesOrderProduct()
        {
        }

        public Guid PriceId { get; set; }

        public Guid SalesOrderId { get; set; }

        public Price Price { get; set; }

        public Product Product => this.Price.Product;

        public MoneyAmount Amount { get; set; }
    }
}
