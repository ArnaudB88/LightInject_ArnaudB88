using System;
using System.Collections.Generic;
using System.Text;
using LightInject;
using LightInjectAb.Business.Domain;

namespace LightInjectAb.Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private readonly IServiceFactory _serviceFactory;

        public UnitOfWork(IDbContext dbContext, IServiceFactory serviceFactory)
        {
            _dbContext = dbContext;
            _serviceFactory = serviceFactory;
        }

        public IGenericRepository<T> RepositoryFor<T>(bool ignoreSoftDeleteFilter = false) where T : class, IEntityBase, new()
        {
            var repo = _serviceFactory.GetInstance<IGenericRepository<T>>();
            return repo;
        }

        public int GetHashcodeOfDbContext()
        {
            return _dbContext.GetHashCode();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }


    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> RepositoryFor<T>(bool ignoreSoftDeleteFilter = false) where T : class, IEntityBase, new();

    }
}
