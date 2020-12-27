using System;
using SomeApplication.Business.Model;

namespace SomeApplication.Interfaces.QueryObjects
{
    public interface IProductQueryObject : IQueryObject<Product>
    {
        IProductQueryObject WithId(Guid productId);

        IProductQueryObject NameContains(string name);

        IProductQueryObject CodeContains(string code);
    }
}
