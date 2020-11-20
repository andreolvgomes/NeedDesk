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
        [Fact(DisplayName = "Operações CRUD")]
        [Trait("Status", "Repository")]
        public void CrudTest()
        {
            try
            {
                IStatusRepository statusRepository = new StatusRepository(Test.Connect);

                // test insert
                var id = (Guid)statusRepository.Insert(CreateStatus.NewStatus());
                Assert.True(!id.IsEmpty());

                // test get by id
                Status status = statusRepository.FindById(id);
                Assert.True(status != null);

                // test update
                status.CreateAt = DateTime.Now;
                var rowscuccess = statusRepository.Update(status);
                Assert.True(rowscuccess > 0);

                // test delete
                statusRepository.Delete(status);

                for (int i = 1; i <= 5; i++)
                    statusRepository.Insert(CreateStatus.NewStatus());

                var list = statusRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
