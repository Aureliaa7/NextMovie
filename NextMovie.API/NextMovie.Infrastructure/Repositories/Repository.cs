using Microsoft.EntityFrameworkCore;
using NextMovie.Domain.Entities;
using NextMovie.Domain.Interfaces;
using NextMovie.Infrastructure.Data;
using System.Linq.Expressions;

namespace NextMovie.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly MovieDbContext context;

        public Repository(MovieDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await context.Set<T>().FindAsync(id);

            return result;
        }

        public Task<int> RemoveByIdAsync(Guid id)
        {
            return context.Set<T>().Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);

            return Task.FromResult(entity);
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().AnyAsync(filter);
        }

        public Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            int? skip = null,
            int? take = null,
            bool trackChanges = true,
            params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> entities = trackChanges ? context.Set<T>() : context.Set<T>().AsNoTracking();

            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            if (skip != null)
            {
                entities = entities.Skip(skip.Value);
            }

            if (take != null)
            {
                entities = entities.Take(take.Value);
            }

            entities = IncludeNavigationProperties(entities, includes);

            return Task.FromResult(entities);
        }

        public Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> entities = context.Set<T>();

            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            entities = IncludeNavigationProperties(entities, includes);

            return entities.FirstOrDefaultAsync();
        }

        private static IQueryable<T> IncludeNavigationProperties(IQueryable<T> entities, params Expression<Func<T, object>>[]? includes)
        {
            if (includes == null || includes.Length == 0)
            {
                return entities;
            }

            foreach (var property in includes)
            {
                entities = entities.Include(property);
            }

            return entities;
        }
    }
}
