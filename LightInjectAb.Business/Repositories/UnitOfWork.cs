using System;
using System.Collections.Generic;
using System.Text;
using LightInject;

namespace LightInjectAb.Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        //private readonly Scope _scope;//Wanted code

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public UnitOfWork(IDbContext dbContext, Scope scope)//Wanted code
        //{
        //    _dbContext = dbContext;
        //    _scope = scope;
        //}

        public IGenericRepository<T> RepositoryFor<T>(bool ignoreSoftDeleteFilter = false) where T : class,  new()
        {
            /* Current code: retrieve repo from container. This results in exception when accessed from the web api project because of a missing scope.
             * Wanted code: we should be able to access the scope so the repo can be retrieved from the active scope
             */
            var repo = ContainerManager.Container.GetInstance<IGenericRepository<T>>();

            //Example of wanted code: use scope when running application starts scopes (eg. web api) or use root container if no scopes are used (eg. console app)
            //var repo = (_scope ?? ContainerManager.Container).GetInstance<IGenericRepository<T>>();

            return repo;
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
        IGenericRepository<T> RepositoryFor<T>(bool ignoreSoftDeleteFilter = false) where T : class, new();

    }
}
