using ModelContract.Entities;
using System;
using System.Threading.Tasks;

namespace ModelContract.Interfaces.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        /// <summary>
        /// Save all the changes made accros different repositories
        /// within the unitOfWork life scope
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Asynchronously save all the changes made accros different repositories
        /// within the unitOfWork life scope
        /// </summary>
        Task SaveChangesAsync();
    }
}
