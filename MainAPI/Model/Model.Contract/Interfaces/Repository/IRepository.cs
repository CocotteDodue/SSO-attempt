using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ModelContract.Interfaces.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<int> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int entityId);
        Task<TEntity> Get(int entityId);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Search(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
