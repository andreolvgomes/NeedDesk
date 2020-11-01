﻿using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class CategoriaClassificacaoRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                ICategoriaClassificacaoRepository categoriaClassificacaoRepository = new CategoriaClassificacaoRepository();

                // test insert
                var id = (Int64)categoriaClassificacaoRepository.Insert(NewDepartamentoCategoria());
                Assert.True(id > 0);

                // test get by id
                CategoriaClassificacao categoriaClassificacao = categoriaClassificacaoRepository.FindById(id);
                Assert.True(categoriaClassificacao != null);

                // test update
                categoriaClassificacao.CreateAt = DateTime.Now;
                var rowscuccess = categoriaClassificacaoRepository.Update(categoriaClassificacao);
                Assert.True(rowscuccess > 0);

                // test delete
                categoriaClassificacaoRepository.Delete(categoriaClassificacao);

                for (int i = 1; i <= 5; i++)
                    categoriaClassificacaoRepository.Insert(NewDepartamentoCategoria());

                var list = categoriaClassificacaoRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private CategoriaClassificacao NewDepartamentoCategoria()
        {
            return new CategoriaClassificacao()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Cat_id = CreateCategoria.Categoria().Cat_id,
                Cla_id = CreateClassificacao.Classificacao().Cla_id
            };
        }
    }
}
