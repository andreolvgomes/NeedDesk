using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class ClassificacaoRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IClassificacaoRepository classificacaoRepository = new ClassificacaoRepository(Test.Connect);

                // test insert
                var id = (Int64)classificacaoRepository.Insert(CreateClassificacao.NewClassificacao());
                Assert.True(id > 0);

                // test get by id
                Classificacao classificacao = classificacaoRepository.FindById(id);
                Assert.True(classificacao != null);

                // test update
                classificacao.CreateAt = DateTime.Now;
                var rowscuccess = classificacaoRepository.Update(classificacao);
                Assert.True(rowscuccess > 0);

                // test delete
                classificacaoRepository.Delete(classificacao);

                for (int i = 1; i <= 5; i++)
                    classificacaoRepository.Insert(CreateClassificacao.NewClassificacao());

                var list = classificacaoRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
