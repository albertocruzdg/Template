using System;
using System.Collections.Generic;
using SomeApplication.Business.Model;

namespace SomeApplication.Business.Interfaces
{
    public interface IPrices : ICollectionWrapper<Price>
    {
        IPrices For(Guid productId);

        IPrices For(IEnumerable<Guid> productIds);
        
        IPrices ExcludeExpired();
        
        IPrices For(IProducts products);
    }
}
