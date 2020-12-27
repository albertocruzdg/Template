using System.Collections;
using System.Collections.Generic;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.QueryObjects;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Business.Collections
{
    public abstract class QueryObject<T> : IEnumerable<T>, IQueryObject<T>
        where T : Entity
    {
        public QueryObject(IApplicationRepository repository)
        {
            this.Collection = repository.Queryable<T>();
        }

        public QueryObject(IEnumerable<T> collection)
        {
            this.Collection = collection;
        }

        public IEnumerable<T> Collection { get; protected set; }

        public IEnumerator<T> GetEnumerator() => this.Collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
