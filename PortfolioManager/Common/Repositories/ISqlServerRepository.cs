using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    /// <summary>
    /// Generic repository interface for Sql Server
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISqlServerRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all the entities
        /// </summary>
        /// <returns>TEntity</returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Inserts an Entity
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Update(TEntity entity);
        /// <summary>
        /// Finds an entity by a searchterm delegate.
        /// </summary>
        /// <param name="searchTerm">Delegate inside an expression tree.</param>
        /// <returns>Task TEntity </returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> searchTerm);
        /// <summary>
        /// Finds a group of entities by a search term.
        /// </summary>
        /// <param name="searchTerm">Delegate inside an expression tree.</param>
        /// <returns>List of the entities</returns>
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> searchTerm);
        /// <summary>
        /// Saves the state of the current context.
        /// </summary>
        /// <returns>True if succesful</returns>
        Task<bool> SaveAsync();
    }
}
