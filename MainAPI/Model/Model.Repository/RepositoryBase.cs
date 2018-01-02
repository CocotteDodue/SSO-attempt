using ModelContract.Interfaces;
using ModelContract.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModelRepository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected DbSet<TEntity> _set;
        
        public RepositoryBase(DbSet<TEntity> set)
        {
            _set = set;
        }
        
        public async Task<int> Create(TEntity entity)
        {
            var newEntity = await _set.AddAsync(entity);
            return newEntity.Entity.Id;
        }

        public async Task<bool> Delete(int entityId)
        {
            var forDelete = await Get(entityId);
            _set.Remove(forDelete);
            return true;
        }
        
        public async Task<TEntity> Get(int entityId)
        {
            return await _set.SingleOrDefaultAsync(s => s.Id == entityId);
        }
        
        public virtual async Task<IEnumerable<TEntity>> Search(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _set.ToListAsync();
        }
        
        public async Task<bool> Update(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);
            return true;
        }
    }
}
