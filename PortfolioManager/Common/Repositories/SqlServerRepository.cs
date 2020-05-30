using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class SqlServerRepository<TEntity> : ISqlServerRepository<TEntity> where TEntity : class
    {
        private readonly DbContext dbContext;
        private DbSet<TEntity> Entities { get; }
        public SqlServerRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.Entities = dbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity) => Entities.Remove(entity);
        public IQueryable<TEntity> GetAll() => Entities.AsNoTracking();
        public void Insert(TEntity entity) => Entities.Add(entity);
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> searchTerm) 
            => await Entities.FirstOrDefaultAsync(searchTerm);
        public void Update(TEntity entity) => dbContext.Update(entity);
        public async Task<bool> SaveAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result >= 0;
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> searchTerm) => await Entities.Where(searchTerm).ToListAsync();
    }
}
