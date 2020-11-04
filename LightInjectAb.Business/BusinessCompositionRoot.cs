using LightInject;
using LightInjectAb.Business.Managers.DetailsMapping;
using LightInjectAb.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business
{
    public class BusinessCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry registry)
        {
            //DbContext should be registered as per scope
            registry.RegisterScoped<IDbContext, DbContext>();

            registry.RegisterScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            registry.RegisterScoped<IUnitOfWork>(factory => new UnitOfWork(factory.GetInstance<IDbContext>(), factory));

            registry.Register<IFoo, Foo>();

            #region managers

            registry.RegisterAssembly(GetType().Assembly, (serviceType, implementingType) =>
                serviceType.IsConstructedGenericType &&
                (
                    serviceType.GetGenericTypeDefinition() == typeof(IDetailsMapper<,>)
                ));

            //register all business managers as transient
            registry.RegisterAssembly(GetType().Assembly//, () => new PerScopeLifetime()
                , (serviceType, implementingType) =>
                serviceType.Namespace.StartsWith("LightInjectAb.Business.Managers.Interfaces"));


            #endregion managers
        }

    }
}
