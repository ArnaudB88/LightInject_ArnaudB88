using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Domain
{
    public class Company : IEntityBase
    {
        public Company()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
