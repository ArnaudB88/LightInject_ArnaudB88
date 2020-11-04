using LightInject;
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
            registry.RegisterScoped<IDbContext,DbContext>();

            registry.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            registry.Register<IUnitOfWork, UnitOfWork>();

            registry.Register<IFoo, Foo>();
        }

    }
}
