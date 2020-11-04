using LightInjectAb.Business.Domain;
using LightInjectAb.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectAb.Business.Managers.DetailsMapping
{
    public interface IDetailsMapper<in TDto, in TDomain>
        where TDomain : class, IEntityBase
        where TDto : DtoBase
    {
        Task MapDetailsAsync(TDto fromDto, TDomain toDomainEntity, bool insertMode);
    }

    public interface IBeforeMapFieldsUpdater<in TDto, in TDomain>
        where TDomain : class, IEntityBase
        where TDto : DtoBase
    {
        void UpdateFieldsBeforeMap(TDto fromDto, TDomain toDomainEntity, bool insertMode);
    }

    public interface IAfterMapDetailsFieldsUpdater<in TDto, in TDomain>
        where TDomain : class, IEntityBase
        where TDto : DtoBase
    {
        Task UpdateFieldsAfterMapDetailsAsync(TDto fromDto, TDomain toUpdatedDomainEntity, bool insertMode);
    }

    public interface IAfterMapFieldsUpdater<in TDto, in TDomain>
        where TDomain : class, IEntityBase
        where TDto : DtoBase
    {
        void UpdateFieldsAfterMap(TDto fromDto, TDomain toUpdatedDomainEntity, bool insertMode);
    }
}
