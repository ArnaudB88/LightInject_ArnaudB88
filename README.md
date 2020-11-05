# LightInject_ArnaudB88

This repo is created for illustrating LightInject issue 549:
https://github.com/seesharper/LightInject/issues/549

How to reproduce:
- build solution
- run LightInjectAb.Web.Api project
- the swagger page should open, otherwise open 'https://localhost:44372/swagger' in a browser

Example 1: (fixed)
- try endpoint 'GET LightInject/Issue549' from inside the swagger page
- exception occurs in LightInjectAb.Business.Repositories.UnitOfWork.RepositoryFor<T>()

Example 2: (not fixed)
- try endpoint 'POST LightInject/Issue549/SaveCompany' from inside the swagger page
- exception occurs in LightInjectAb.Business.Managers.ManagerBase.MapDetailsAsync()

The created unit tests, executing same code, do not throw an exception:
LightInjectAb.Tests.Issue549.GetRepository_Should_Work()
LightInjectAb.Tests.Issue549.InsertOrUpdateAsync_Should_Work()
