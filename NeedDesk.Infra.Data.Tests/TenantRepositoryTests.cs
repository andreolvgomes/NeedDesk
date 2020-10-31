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
                ITenantRepository tenantRepository = new TenantRepository();

                // test insert
                var id = (Int64)tenantRepository.Insert(new Tenant() { Identifier = Guid.NewGuid() });
                Assert.True(id > 0);

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
                    tenantRepository.Insert(new Tenant() { Identifier = Guid.NewGuid() });

                var list = tenantRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}