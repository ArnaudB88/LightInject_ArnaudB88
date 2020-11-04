using LightInjectAb.Business.Domain;
using LightInjectAb.Business.Dto;
using LightInjectAb.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectAb.Business.Managers.DetailsMapping
{
    public class CompanyDetailsMapper : IDetailsMapper<CompanyDto, Company>
    {
        private readonly IUnitOfWork _uow;

        public CompanyDetailsMapper(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task MapDetailsAsync(CompanyDto dto, Company company, bool insertMode)
        {
            //logic
            var repo = _uow.RepositoryFor<Company>();
            repo.GetHashCode();

            //Example logic
            //if(dto.Address == null)
            //{
            //    if(company.AddressId != null)
            //    {
            //        await repo.MarkAsDeletedByIdAsync<Address>(company.AddressId);
            //    }
            //}
        }
    }

}
