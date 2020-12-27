using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;

namespace SomeApplication.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DatabaseContext context;

        public ApplicationRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync<T>(T entity) 
            where T : Entity => await this.Set<T>().AddAsync(entity);

        public async Task<T> GetAsync<T>(Guid id) 
            where T : Entity => await this.Set<T>().FindAsync(id);

        public IQueryable<T> Queryable<T>()
            where T : Entity => this.Set<T>().AsQueryable();

        public Task UpdateAsync<T>(T entity) 
            where T : Entity
        {
            this.Set<T>().Update(entity);

            return Task.CompletedTask;
        }

        private DbSet<T> Set<T>() 
            where T : Entity => this.context.Set<T>();
    }
}
