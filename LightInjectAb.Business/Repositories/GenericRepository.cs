using System;
using System.Collections.Generic;
using System.Text;

namespace LightInjectAb.Business.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
            where T : class, new()
    {
        private readonly IDbContext _dbContext;

        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }


    public interface IGenericRepository<T>
        where T : class
    {
    }
}
