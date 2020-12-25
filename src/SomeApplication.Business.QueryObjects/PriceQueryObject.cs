using System;
using System.Collections.Generic;
using System.Linq;
using SomeApplication.Business.Interfaces;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Business.Collections
{
    public class PriceQueryObject : QueryObject<Price>, IPrices
    {
        public PriceQueryObject(IApplicationRepository repository)
            : base(repository)
        {
        }

        public IPrices ExcludeExpired()
        {
            this.Collection = this.Collection.Where(x => x.DueDate > DateTimeOffset.Now);

            return this;
        }

        public IPrices For(IEnumerable<Guid> productIds)
        {
            this.Collection = this.Collection.Where(x => productIds.Contains(x.ProductId));

            return this;
        }

        public IPrices For(IProducts products)
        {
            return this.For(products.Select(x => x.Id));
        }
    }
}
