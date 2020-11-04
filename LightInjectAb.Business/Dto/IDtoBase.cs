using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Dto
{
    public interface IDtoBase<T>
    {
        T Id { get; set; }
    }
}
