using LightInjectAb.Business.Domain;
using LightInjectAb.Business.Dto;
using LightInjectAb.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using LightInjectAb.Business.Managers.DetailsMapping;

namespace LightInjectAb.Business.Managers
{
    public abstract class ManagerBase<TDomain> : IDisposable
        where TDomain : class, IEntityBase, new()
    {
        protected readonly IUnitOfWork Uow;

        protected ManagerBase(IUnitOfWork uow)
        {
            Uow = uow;
        }

        protected virtual async Task<TDomain> GetDomainEntityAsync(Guid id)
        {
            return await Uow.RepositoryFor<TDomain>().GetByIdAsync(id);
        }

        public async Task<Guid> InsertOrUpdateAsync<TDto>(TDto dto) where TDto : DtoBase
        {
            var insertMode = false;

            var domainEntity = await GetDomainEntityAsync(dto.Id);

            if (domainEntity == null)
            {
                insertMode = true;

                domainEntity = new TDomain();
            }

            UpdateFieldsBeforeMap(dto, domainEntity, insertMode);

            //domainEntity = Mapper.Map(dto, domainEntity); //without mapping the details (property is ignored in mapping recipe)

            UpdateFieldsAfterMap(dto, domainEntity, insertMode);

            //map detail object tree
            await MapDetailsAsync(dto, domainEntity, insertMode);

            await UpdateFieldsAfterMapDetailsAsync(dto, domainEntity, insertMode);

            if (insertMode)
            {
                //Uow.RepositoryFor<TDomain>().Insert(domainEntity);
            }

            return domainEntity.Id;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Uow.Dispose();
            }

            _disposed = true;
        }


        private async Task MapDetailsAsync<TDto>(TDto dto, TDomain domainEntity, bool insertMode) where TDto : DtoBase
        {
            var detailsMapper = ContainerManager.Container.TryGetInstance<IDetailsMapper<TDto, TDomain>>();

            if (detailsMapper != null)
            {
                await detailsMapper.MapDetailsAsync(dto, domainEntity, insertMode);
            }
        }

        private void UpdateFieldsBeforeMap<TDto>(TDto dto, TDomain domainEntity, bool insertMode) where TDto : DtoBase
        {
            var beforeMapFieldsUpdater = ContainerManager.Container.TryGetInstance<IBeforeMapFieldsUpdater<TDto, TDomain>>();

            beforeMapFieldsUpdater?.UpdateFieldsBeforeMap(dto, domainEntity, insertMode);
        }

        private void UpdateFieldsAfterMap<TDto>(TDto dto, TDomain updatedDomainEntity, bool insertMode) where TDto : DtoBase
        {
            var afterMapFieldsUpdater = ContainerManager.Container.TryGetInstance<IAfterMapFieldsUpdater<TDto, TDomain>>();

            afterMapFieldsUpdater?.UpdateFieldsAfterMap(dto, updatedDomainEntity, insertMode);
        }

        private async Task UpdateFieldsAfterMapDetailsAsync<TDto>(TDto dto, TDomain updatedDomainEntity, bool insertMode) where TDto : DtoBase
        {
            var afterMapDetailsFieldsUpdater = ContainerManager.Container.TryGetInstance<IAfterMapDetailsFieldsUpdater<TDto, TDomain>>();

            if (afterMapDetailsFieldsUpdater != null)
            {
                await afterMapDetailsFieldsUpdater.UpdateFieldsAfterMapDetailsAsync(dto, updatedDomainEntity, insertMode);
            }
        }

    }
}
