using System;

namespace SomeApplication.Business.Model
{
    public class Price : Entity
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public MoneyAmount Amount { get; set; }

        public DateTimeOffset? DueDate { get; set; }

        public void MarkAsExpired() => this.DueDate = DateTimeOffset.Now;
    }
}