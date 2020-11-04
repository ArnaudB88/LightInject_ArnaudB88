using LightInjectAb.Business.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectAb.Business.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
            where T : class, IEntityBase, new()
    {
        private readonly IDbContext _dbContext;

        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return null;//returns entity from database
        }
    }


    public interface IGenericRepository<T>
        where T : IEntityBase
    {
        Task<T> GetByIdAsync(Guid id);
    }
}
