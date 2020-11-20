using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class ColaboradorRepositoryTests
    {
        [Fact(DisplayName = "Operações CRUD")]
        [Trait("Colaboradores", "Repository")]
        public void CrudTest()
        {
            try
            {
                IColaboradorRepository colaboradorRepository = new ColaboradorRepository(Test.Connect);

                // test insert
                var id = (Guid)colaboradorRepository.Insert(CreateColaborador.NewColaborador());
                Assert.True(!id.IsEmpty());

                // test get by id
                Colaborador colaborador = colaboradorRepository.FindById(id);
                Assert.True(colaborador != null);

                // test update
                colaborador.CreateAt = DateTime.Now;
                var rowscuccess = colaboradorRepository.Update(colaborador);
                Assert.True(rowscuccess > 0);

                // test delete
                colaboradorRepository.Delete(colaborador);

                for (int i = 1; i <= 5; i++)
                    colaboradorRepository.Insert(CreateColaborador.NewColaborador());

                var list = colaboradorRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
