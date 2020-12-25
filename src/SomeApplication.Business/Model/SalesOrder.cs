using System;
using System.Collections.Generic;
using SomeApplication.Business.Interfaces;

namespace SomeApplication.Business.Model
{
    public class SalesOrder : Entity
    {
        public SalesOrder()
        {
            this.Date = DateTimeOffset.Now;
            this.Detail = new List<SalesOrderProduct>();
        }

        public SalesOrder(IPrices prices)
            : this()
        {
            foreach (var price in prices)
            {
                this.Detail.Add(new SalesOrderProduct(price));
            }
        }

        public DateTimeOffset? Date { get; set; }

        public virtual ICollection<SalesOrderProduct> Detail { get; set; }
    }
}
