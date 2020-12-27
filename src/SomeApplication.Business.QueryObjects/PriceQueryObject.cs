using System;
using System.Collections.Generic;
using System.Linq;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.QueryObjects;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Business.Collections
{
    public class PriceQueryObject : QueryObject<Price>, IPriceQueryObject
    {
        public PriceQueryObject(IApplicationRepository repository)
            : base(repository)
        {
        }

        private PriceQueryObject(IEnumerable<Price> collection)
            : base(collection)
        {
        }

        public IPriceQueryObject ExcludeExpired()
        {
            var newCollection = this.Collection.Where(x => x.DueDate is null || x.DueDate > DateTimeOffset.Now);

            return new PriceQueryObject(newCollection);
        }

        public IPriceQueryObject For(IEnumerable<Guid> productIds)
        {
            var newCollection = this.Collection.Where(x => productIds.Contains(x.ProductId));

            return new PriceQueryObject(newCollection);
        }

        public IPriceQueryObject For(IEnumerable<Product> products)
        {
            return this.For(products.Select(x => x.Id));
        }

        public IPriceQueryObject For(Guid productId)
        {
            var newCollection = this.Collection.Where(x => x.ProductId == productId);

            return new PriceQueryObject(newCollection);
        }
    }
}
