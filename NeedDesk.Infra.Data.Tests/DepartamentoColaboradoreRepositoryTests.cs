using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class DepartamentoColaboradoreRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IDepartamentoColaboradoreRepository departamentoColaboradoreRepository = new DepartamentoColaboradoreRepository(Test.Connect);

                // test insert
                var id = (Int64)departamentoColaboradoreRepository.Insert(NewDepartamentoColaborador());
                Assert.True(id > 0);

                // test get by id
                DepartamentoColaborador departamentoColaborador = departamentoColaboradoreRepository.FindById(id);
                Assert.True(departamentoColaborador != null);

                // test update
                departamentoColaborador.CreateAt = DateTime.Now;
                var rowscuccess = departamentoColaboradoreRepository.Update(departamentoColaborador);
                Assert.True(rowscuccess > 0);

                // test delete
                departamentoColaboradoreRepository.Delete(departamentoColaborador);

                for (int i = 1; i <= 5; i++)
                    departamentoColaboradoreRepository.Insert(NewDepartamentoColaborador());

                var list = departamentoColaboradoreRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DepartamentoColaborador NewDepartamentoColaborador()
        {
            return new DepartamentoColaborador()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Dep_id = CreateDepartamento.Departamento().Dep_id,
                Col_id = CreateColaborador.Colaborador().Col_id
            };
        }
    }
}
