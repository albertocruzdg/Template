using System.Collections.Generic;
using SomeApplication.Business.Model;

namespace SomeApplication.Interfaces.QueryObjects
{
    public interface IQueryObject<T> : IEnumerable<T>
        where T : Entity
    {
        IEnumerable<T> Collection { get; }
    }
}
