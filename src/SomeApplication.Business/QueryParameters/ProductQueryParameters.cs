using System;
using SomeApplication.Business.Interfaces;

namespace SomeApplication.Business.QueryParameters
{
    public class ProductQueryParameters
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public IProducts Filter(IProducts products)
        {
            if (this.Id.HasValue)
            {
                products = products.WithId(Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                products = products.NameContains(Name);
            }

            if (!string.IsNullOrWhiteSpace(this.Code))
            {
                products = products.CodeContains(this.Code);
            }

            return products;
        }
    }
}
