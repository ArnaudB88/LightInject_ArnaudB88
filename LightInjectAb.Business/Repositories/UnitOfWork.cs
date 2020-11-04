using System;
using System.Collections.Generic;
using System.Text;
using LightInject;

namespace LightInjectAb.Business.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceFactory _serviceFactory;

        public UnitOfWork(IServiceFactory serviceFactory)//Wanted code
        {
            _serviceFactory = serviceFactory;
        }

        public IGenericRepository<T> RepositoryFor<T>(bool ignoreSoftDeleteFilter = false) where T : class, new()
        {

            var repo = _serviceFactory.GetInstance<IGenericRepository<T>>();

            //Example of wanted code: use scope when running application starts scopes (eg. web api) or use root container if no scopes are used (eg. console app)
            //var repo = (_scope ?? ContainerManager.Container).GetInstance<IGenericRepository<T>>();

            return repo;
        }
    }


    public interface IUnitOfWork
    {
        IGenericRepository<T> RepositoryFor<T>(bool ignoreSoftDeleteFilter = false) where T : class, new();

    }
}
