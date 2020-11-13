using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class TenantRepositoryTests
    {
        public TenantRepositoryTests()
        {
        }

        [Fact]
        public void CrudTest()
        {
            try
            {
                ITenantRepository tenantRepository = new TenantRepository(Test.Connect);

                // test insert
                var id = (Guid)tenantRepository.Insert(new Tenant() { });
                Assert.True(!id.IsEmpty());

                // test get by id
                Tenant tenant = tenantRepository.FindById(id);
                Assert.True(tenant != null);

                // test update
                tenant.CreateAt = DateTime.Now;
                var rowscuccess = tenantRepository.Update(tenant);
                Assert.True(rowscuccess > 0);

                // test delete
                tenantRepository.Delete(tenant);

                for (int i = 1; i <= 5; i++)
                    tenantRepository.Insert(new Tenant() { });

                var list = tenantRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}