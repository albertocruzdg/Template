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

        private PriceQueryObject(IEnumerable<Price> collection)
            : base(collection)
        {
        }

        public IPrices ExcludeExpired()
        {
            var newCollection = this.Collection.Where(x => x.DueDate > DateTimeOffset.Now);

            return new PriceQueryObject(newCollection);
        }

        public IPrices For(IEnumerable<Guid> productIds)
        {
            var newCollection = this.Collection.Where(x => productIds.Contains(x.ProductId));

            return new PriceQueryObject(newCollection);
        }

        public IPrices For(IProducts products)
        {
            return this.For(products.Select(x => x.Id));
        }

        public IPrices For(Guid productId)
        {
            var newCollection = this.Collection.Where(x => x.ProductId == productId);

            return new PriceQueryObject(newCollection);
        }
    }
}
