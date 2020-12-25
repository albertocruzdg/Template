using System;
using System.Linq;
using SomeApplication.Business.Interfaces;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Business.Collections
{
    public class ProductQueryObject : QueryObject<Product>, IProducts
    {
        public ProductQueryObject(IApplicationRepository repository)
            : base(repository)
        {
        }

        public IProducts WithId(Guid productId)
        {
            this.Collection = this.Collection.Where(x => x.Id == productId);

            return this;
        }

        public IProducts NameContains(string name)
        {
            this.Collection = this.Collection.Where(x => x.Name.Contains(name));

            return this;
        }

        public IProducts CodeContains(string code)
        {
            this.Collection = this.Collection.Where(x => x.Code.Contains(code));

            return this;
        }
    }
}
