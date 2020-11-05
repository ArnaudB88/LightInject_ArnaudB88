using LightInjectAb.Business.Domain;
using LightInjectAb.Business.Managers.Interfaces;
using LightInjectAb.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Managers
{
    public class DeviceManager : ManagerBase<Device>, IDeviceManager
    {
        public DeviceManager(IUnitOfWork uow)//in actual code a lot more parameters
            : base(uow)
        {
        }

    }
}
