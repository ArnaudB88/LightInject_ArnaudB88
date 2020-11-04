using LightInjectAb.Business;
using LightInjectAb.Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectAb.Tests
{
    /// <summary>
    /// Test class for issue 549
    /// - This unit test succeeds correctly
    /// - starting the web api project and trying the single endpoint will trigger an exception when running the same code
    /// </summary>
    [TestClass]
    public class Issue549 : TestsBase
    {
        [TestMethod]
        public void GetRepository_Should_Work()
        {
            var uow = GetInstance<IUnitOfWork>();
            var repo = uow.RepositoryFor<Foo>();

            //Succeeds indeed while working with a scope
            Assert.IsNotNull(repo);
        }
    }
}
