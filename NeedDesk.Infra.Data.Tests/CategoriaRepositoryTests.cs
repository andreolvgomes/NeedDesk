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
        [Fact(DisplayName = "Operações CRUD")]
        [Trait("Categorias", "Repository")]
        public void CrudTest()
        {
            var tenant_id = CreateTenant.Tenant_id();

            try
            {
                ICategoriaRepository categoriaRepository = new CategoriaRepository(Test.Connect);

                // test insert
                var id = (Guid)categoriaRepository.Insert(CreateCategoria.NewCategoria());
                Assert.True(!id.IsEmpty());

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
                    categoriaRepository.Insert(CreateCategoria.NewCategoria());

                var list = categoriaRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}