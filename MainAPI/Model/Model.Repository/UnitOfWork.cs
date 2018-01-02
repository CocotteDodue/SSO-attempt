using Microsoft.EntityFrameworkCore;
using Model;
using ModelContract;
using ModelContract.Interfaces;
using ModelContract.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ModelRepository
{
    public class UnitOfWork: IUnitOfWork
    {
        protected MainApiDbContext _context;
        protected bool _disposed = false;

        public UnitOfWork(MainApiDbContextInstance contextCreationInfo)
        {
            _context = contextCreationInfo.ExistingDbContext != null
                ? (MainApiDbContext)contextCreationInfo.ExistingDbContext
                : new MainApiDbContext(new DbContextOptionsBuilder<MainApiDbContext>()
                                                    .UseSqlServer(contextCreationInfo.ConnectionString)
                                                    .Options);
        }

        public IRepository<TEntity> GetRepository<TEntity> () 
            where TEntity : class, IEntity
        {
            var set = _context.Set<TEntity>();
            return new RepositoryBase<TEntity>(set);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed
                && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
