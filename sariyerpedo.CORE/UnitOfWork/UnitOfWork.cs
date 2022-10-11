using sariyerpedo.CORE.Repository;
using sariyerpedo.DAL;
using sariyerpedo.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.CORE.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private readonly sariyerpedodbcontext _dbContext;

        public UnitOfWork(sariyerpedodbcontext dbContext)
        {
            _dbContext = dbContext;
            Repository = new Repository<T>(dbContext);
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
        public IRepository<T> Repository { get; }
    }
}
