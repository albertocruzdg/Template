using System;
using System.Collections.Generic;

namespace SomeApplication.Business.Model
{
    public class SalesOrder : Entity
    {
        public SalesOrder()
        {
            this.Date = DateTimeOffset.Now;
            this.Detail = new List<SalesOrderProduct>();
        }

        public DateTimeOffset? Date { get; set; }

        public virtual ICollection<SalesOrderProduct> Detail { get; set; }
    }
}
