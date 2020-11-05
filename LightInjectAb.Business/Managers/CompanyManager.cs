using LightInjectAb.Business.Domain;
using LightInjectAb.Business.Managers.Interfaces;
using LightInjectAb.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Managers
{
    public class CompanyManager : ManagerBase<Company>, ICompanyManager
    {
        private readonly IFoo _foo;

        public CompanyManager(IUnitOfWork uow, IFoo foo)//in actual code a lot more parameters
            : base(uow)
        {
            _foo = foo;
        }

    }
}
