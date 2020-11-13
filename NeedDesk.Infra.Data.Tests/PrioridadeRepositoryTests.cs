using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class PrioridadeRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IPrioridadeRepository prioridadeRepository = new PrioridadeRepository(Test.Connect);

                // test insert
                var id = (Guid)prioridadeRepository.Insert(CreatePrioridade.NewPrioridade());
                Assert.True(!id.IsEmpty());

                // test get by id
                Prioridade prioridade = prioridadeRepository.FindById(id);
                Assert.True(prioridade != null);

                // test update
                prioridade.CreateAt = DateTime.Now;
                var rowscuccess = prioridadeRepository.Update(prioridade);
                Assert.True(rowscuccess > 0);

                // test delete
                prioridadeRepository.Delete(prioridade);

                for (int i = 1; i <= 5; i++)
                    prioridadeRepository.Insert(CreatePrioridade.NewPrioridade());

                var list = prioridadeRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
