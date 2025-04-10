using System.Linq.Expressions;

namespace NextMovie.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Gets entity by id or null if not found
        /// </summary>
        /// <param name="id">The id of the searched entity</param>
        /// <returns>The found entity or null</returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        /// <returns>The added entity</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Removes an entity from the database based on its id
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The number of affected rows</returns>
        Task<int> RemoveByIdAsync(Guid id);

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">The entity to be updated</param>
        /// <returns>The updated entity</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Checks if an entity exists based on the provided filter
        /// </summary>
        /// <param name="filter">The provided filter</param>
        /// <returns>A boolean value indicating whether or not the entity exists</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets all entities that match the provided filter
        /// </summary>
        /// <param name="filter">The provided filter</param>
        /// <param name="skip">The number of entities to be skipped</param>
        /// <param name="take">The number of entities to be retrieved</param>
        /// <param name="trackChanges">Whether or not the EF ChangeTracker should track the returned entities</param>
        /// <param name="includes">The navigation properties to be included</param>
        /// <returns>The found entities</returns>
        Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            int? skip = null,
            int? take = null,
            bool trackChanges = true,
            params Expression<Func<T, object>>[]? includes);

        /// <summary>
        /// Gets the first entity that matches the provided filter or null if not found
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="includes">The navigation properties to be included</param>
        /// <returns>The first entity that matches the provided filter or null</returns>
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[]? includes);

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
