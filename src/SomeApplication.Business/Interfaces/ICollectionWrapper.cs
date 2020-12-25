using System.Collections.Generic;
using SomeApplication.Business.Model;

namespace SomeApplication.Business.Interfaces
{
    public interface ICollectionWrapper<T> : IEnumerable<T>
        where T : Entity
    {
        IEnumerable<T> Collection { get; }
    }
}
