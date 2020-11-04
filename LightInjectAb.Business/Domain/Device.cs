using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Domain
{
    public class Device : IEntityBase
    {
        public Device()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
