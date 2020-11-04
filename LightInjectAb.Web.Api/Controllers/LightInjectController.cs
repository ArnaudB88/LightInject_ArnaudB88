using LightInjectAb.Business;
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

        public LightInjectController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("Issue549")]
        [HttpGet]
        public int GetIssue549()
        {
            var repo = _uow.RepositoryFor<Foo>();
            return repo?.GetHashCode() ?? -1;
        }
    }
}
