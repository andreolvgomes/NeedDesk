using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class DepartamentoCategoriaRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IDepartamentoCategoriaRepository departamentoCategoriaRepository = new DepartamentoCategoriaRepository(Test.Connect);

                // test insert
                var id = (Int64)departamentoCategoriaRepository.Insert(NewDepartamentoCategoria());
                Assert.True(id > 0);

                // test get by id
                DepartamentoCategoria departamentoCategoria = departamentoCategoriaRepository.FindById(id);
                Assert.True(departamentoCategoria != null);

                // test update
                departamentoCategoria.CreateAt = DateTime.Now;
                var rowscuccess = departamentoCategoriaRepository.Update(departamentoCategoria);
                Assert.True(rowscuccess > 0);

                // test delete
                departamentoCategoriaRepository.Delete(departamentoCategoria);

                for (int i = 1; i <= 5; i++)
                    departamentoCategoriaRepository.Insert(NewDepartamentoCategoria());

                var list = departamentoCategoriaRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DepartamentoCategoria NewDepartamentoCategoria()
        {
            return new DepartamentoCategoria()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Dep_id = CreateDepartamento.Departamento().Dep_id,
                Cat_id = CreateCategoria.Categoria().Cat_id
            };
        }
    }
}
