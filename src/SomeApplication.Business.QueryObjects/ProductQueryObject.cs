using System;
using System.Collections.Generic;
using System.Linq;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.QueryObjects;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Business.Collections
{
    public class ProductQueryObject : QueryObject<Product>, IProductQueryObject
    {
        public ProductQueryObject(IApplicationRepository repository)
            : base(repository)
        {
        }

        private ProductQueryObject(IEnumerable<Product> collection)
            : base(collection)
        {

        }

        public IProductQueryObject WithId(Guid productId)
        {
            var newCollection = this.Collection.Where(x => x.Id == productId);

            return new ProductQueryObject(newCollection);
        }

        public IProductQueryObject NameContains(string name)
        {
            var newCollection = this.Collection.Where(x => x.Name.Contains(name));

            return new ProductQueryObject(newCollection);
        }

        public IProductQueryObject CodeContains(string code)
        {
            var newCollection = this.Collection.Where(x => x.Code.Contains(code));

            return new ProductQueryObject(newCollection);
        }
    }
}
