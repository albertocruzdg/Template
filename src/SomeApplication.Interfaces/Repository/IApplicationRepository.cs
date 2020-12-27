using System;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.Model;

namespace SomeApplication.Interfaces.Repository
{
    public interface IApplicationRepository
    {
        Task CreateAsync<T>(T entity) where T : Entity;

        Task UpdateAsync<T>(T entity) where T : Entity;

        Task<T> GetAsync<T>(Guid id) where T : Entity;
        
        IQueryable<T> Queryable<T>() where T : Entity;
    }
}
