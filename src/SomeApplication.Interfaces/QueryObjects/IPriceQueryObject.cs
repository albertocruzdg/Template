using System;
using System.Collections.Generic;
using SomeApplication.Business.Model;

namespace SomeApplication.Interfaces.QueryObjects
{
    public interface IPriceQueryObject : IQueryObject<Price>
    {
        IPriceQueryObject For(Guid productId);

        IPriceQueryObject For(IEnumerable<Guid> productIds);
        
        IPriceQueryObject ExcludeExpired();
        
        IPriceQueryObject For(IProductQueryObject products);
    }
}
