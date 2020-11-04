using LightInject;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LightInjectAb.Business
{
    public static class ContainerManager
    {
        public static IServiceContainer Container { get; private set; }

        public static void Bootstrap(IServiceContainer existingContainer = null)
        {
            InitializeContainer(existingContainer);
        }

        public static void Teardown()
        {
            lock (ContainerSyncObject)
            {
                if (_containerIsConfigured)
                {
                    Container.Dispose();
                    _containerIsConfigured = false;
                }
            }
        }

        private static bool _containerIsConfigured;
        private static readonly object ContainerSyncObject = new object();

        private static void InitializeContainer(IServiceContainer existingContainer = null)
        {
            lock (ContainerSyncObject)
            {
                if (!_containerIsConfigured)
                {
                    var containerOptions = new ContainerOptions();
                    containerOptions.LogFactory = (type) => logEntry => Debug.WriteLine(logEntry.Message);

                    Container = existingContainer ?? new ServiceContainer(containerOptions);

                    if (Container is ServiceContainer)
                        ((ServiceContainer)Container).EnableAnnotatedPropertyInjection();//Needed for annotation for property injection

                    var dllFilePaths = Directory.GetFiles(AppContext.BaseDirectory, "LightInjectAb*.dll");
                    foreach (var dllFilePath in dllFilePaths)
                    {
                        var assembly = Assembly.LoadFrom(dllFilePath);
                        Container.RegisterAssembly(assembly);
                    }
                    var totalRegistrationsNumber = Container.AvailableServices.Count();

                    _containerIsConfigured = true;
                }
            }
        }


    }
}
