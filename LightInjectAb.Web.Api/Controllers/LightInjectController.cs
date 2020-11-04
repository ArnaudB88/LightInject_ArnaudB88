using LightInjectAb.Business;
using LightInjectAb.Business.Domain;
using LightInjectAb.Business.Dto;
using LightInjectAb.Business.Managers.Interfaces;
using LightInjectAb.Business.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightInjectAb.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LightInjectController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ICompanyManager _companyManager;

        public LightInjectController(IUnitOfWork uow, ICompanyManager companyManager)
        {
            _uow = uow;
            _companyManager = companyManager;
        }

        [Route("Issue549")]
        [HttpGet]
        public int GetIssue549()
        {
            var repo = _uow.RepositoryFor<Company>();
            return repo?.GetHashCode() ?? -1;
        }

        [Route("Issue549/SaveCompany")]
        [HttpPost]
        public async Task<Guid> SaveCompanyIssue549()
        {
            var id = await _companyManager.InsertOrUpdateAsync(new CompanyDto());
            return id;
        }
    }
}
