using System;
using SomeApplication.Business.Model;

namespace SomeApplication.Business.Interfaces
{
    public interface IProducts : ICollectionWrapper<Product>
    {
        IProducts WithId(Guid productId);

        IProducts NameContains(string name);

        IProducts CodeContains(string code);
    }
}
