using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectAb.Business
{
    public class Foo : IFoo
    {
        public async Task<bool> ExecuteAsync()
        {
            await Task.Delay(100);
            return true;
        }
    }
    public interface IFoo
    {
        Task<bool> ExecuteAsync();
    }
}
