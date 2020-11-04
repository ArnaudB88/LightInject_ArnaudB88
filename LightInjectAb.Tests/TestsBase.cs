using LightInject;
using LightInjectAb.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Tests
{
    [TestClass]
    public abstract class TestsBase
    {
        protected Scope ServiceFactory;

        [TestInitialize]
        public void Initialize()
        {
            ContainerManager.Bootstrap();
            ServiceFactory = ContainerManager.Container.BeginScope();
            
        }

        [TestCleanup]
        public void CleanUp()
        {
            ServiceFactory.Dispose();
            ContainerManager.Container.Dispose();
        }

        protected T GetInstance<T>()
        {
            return ServiceFactory.GetInstance<T>();
        }

    }
}
