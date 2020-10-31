using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class StatusRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IStatusRepository statusRepository = new StatusRepository();

                // test insert
                var id = (Int64)statusRepository.Insert(NewClassificacao());
                Assert.True(id > 0);

                // test get by id
                Status status = statusRepository.GetById(id);
                Assert.True(status != null);

                // test update
                status.CreateAt = DateTime.Now;
                var rowscuccess = statusRepository.Update(status);
                Assert.True(rowscuccess > 0);

                // test delete
                statusRepository.Delete(status);

                for (int i = 1; i <= 5; i++)
                    statusRepository.Insert(NewClassificacao());

                var list = statusRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Status NewClassificacao()
        {
            return new Status()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Sta_descricao = Guid.NewGuid().ToString(),
                Identifier = Guid.NewGuid()
            };
        }
    }
}
