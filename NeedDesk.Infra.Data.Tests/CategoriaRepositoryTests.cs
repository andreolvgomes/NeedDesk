using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class CategoriaRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            var tenant_id = CreateTenant.Tenant_id();

            try
            {
                ICategoriaRepository categoriaRepository = new CategoriaRepository();

                // test insert
                var id = (Int64)categoriaRepository.Insert(NewCliente());
                Assert.True(id > 0);

                // test get by id
                Categoria categoria = categoriaRepository.FindById(id);
                Assert.True(categoria != null);

                // test update
                categoria.CreateAt = DateTime.Now;
                var rowscuccess = categoriaRepository.Update(categoria);
                Assert.True(rowscuccess > 0);

                // test delete
                categoriaRepository.Delete(categoria);

                for (int i = 1; i <= 5; i++)
                    categoriaRepository.Insert(NewCliente());

                var list = categoriaRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Categoria NewCliente()
        {
            return new Categoria()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Cat_descricao = Faker.Company.Name(),
            };
        }
    }
}