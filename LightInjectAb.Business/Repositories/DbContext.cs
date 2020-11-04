using System;

namespace LightInjectAb.Business.Repositories
{
    public class DbContext : IDbContext
    {
        public void Dispose()
        {
            
        }
    }
    public interface IDbContext : IDisposable
    {

    }
}
