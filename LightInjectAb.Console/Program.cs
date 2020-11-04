using System;
using LightInject;
using LightInjectAb.Business;
using LightInjectAb.Business.Repositories;

namespace LightInjectAb.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            ContainerManager.Bootstrap(container);
            using (var scope = container.BeginScope())
            {
                var unitOfWork = container.GetInstance<IUnitOfWork>();
            }

        }
    }
}
