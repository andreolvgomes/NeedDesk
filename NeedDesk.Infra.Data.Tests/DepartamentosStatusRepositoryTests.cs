using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class DepartamentosStatusRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IDepartamentosStatusRepository departamentosStatusRepository = new DepartamentosStatusRepository(Test.Connect);

                // test insert
                var id = (Guid)departamentosStatusRepository.Insert(NewDepartamentosStatus());
                Assert.True(!id.IsEmpty());

                // test get by id
                DepartamentosStatus departamentosStatus = departamentosStatusRepository.FindById(id);
                Assert.True(departamentosStatus != null);

                // test update
                departamentosStatus.CreateAt = DateTime.Now;
                var rowscuccess = departamentosStatusRepository.Update(departamentosStatus);
                Assert.True(rowscuccess > 0);

                // test delete
                departamentosStatusRepository.Delete(departamentosStatus);

                for (int i = 1; i <= 5; i++)
                    departamentosStatusRepository.Insert(NewDepartamentosStatus());

                var list = departamentosStatusRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DepartamentosStatus NewDepartamentosStatus()
        {
            return new DepartamentosStatus()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Dep_id = CreateDepartamento.Departamento().Dep_id,
                Sta_id = CreateStatus.Status().Sta_id
            };
        }
    }
}
