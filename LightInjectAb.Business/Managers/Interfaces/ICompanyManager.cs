using LightInjectAb.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectAb.Business.Managers.Interfaces
{
    public interface ICompanyManager
    {
        Task<Guid> InsertOrUpdateAsync<TDto>(TDto dto) where TDto : DtoBase;
    }
}
