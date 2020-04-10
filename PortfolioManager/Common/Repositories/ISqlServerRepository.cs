using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ISqlServerRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> searchTerm);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> searchTerm);
        Task<bool> SaveAsync();
    }
}
