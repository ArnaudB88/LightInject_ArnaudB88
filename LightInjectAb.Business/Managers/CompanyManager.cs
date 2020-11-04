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
        public CompanyManager(IUnitOfWork uow)
            : base(uow)
        {
        }

    }
}
