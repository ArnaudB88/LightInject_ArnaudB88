# LightInject_ArnaudB88

This repo is created for illustrating LightInject issue 549:
https://github.com/seesharper/LightInject/issues/549

How to reproduce:
- build solution
- run LightInjectAb.Web.Api project
- the swagger page should open, otherwise open 'https://localhost:44372/swagger' in a browser
- try endpoint 'LightInject/Issue549' from inside the swagger page
- exception occurs in LightInjectAb.Business.Repositories.UnitOfWork.RepositoryFor<T>()

The created unit test, executing same code, does not throw an exception:
LightInjectAb.Tests.Issue549.GetRepository_Should_Work()
