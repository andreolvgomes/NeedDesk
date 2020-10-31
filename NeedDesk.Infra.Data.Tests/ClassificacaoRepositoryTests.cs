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
                IClassificacaoRepository classificacaoRepository = new ClassificacaoRepository();

                // test insert
                var id = (Int64)classificacaoRepository.Insert(NewClassificacao());
                Assert.True(id > 0);

                // test get by id
                Classificacao classificacao = classificacaoRepository.GetById(id);
                Assert.True(classificacao != null);

                // test update
                classificacao.CreateAt = DateTime.Now;
                var rowscuccess = classificacaoRepository.Update(classificacao);
                Assert.True(rowscuccess > 0);

                // test delete
                classificacaoRepository.Delete(classificacao);

                for (int i = 1; i <= 5; i++)
                    classificacaoRepository.Insert(NewClassificacao());

                var list = classificacaoRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Classificacao NewClassificacao()
        {
            return new Classificacao()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Cla_descricao = Guid.NewGuid().ToString(),
                Identifier = Guid.NewGuid()
            };
        }
    }
}
