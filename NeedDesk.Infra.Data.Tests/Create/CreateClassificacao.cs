using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateClassificacao
    {
        private static Classificacao ClassificacaoSession;

        public static Classificacao Classificacao()
        {
            if (ClassificacaoSession == null)
            {
                IClassificacaoRepository categoriaClassificacaoRepository = new ClassificacaoRepository();
                var id = categoriaClassificacaoRepository.Insert(NewClassificacao());
                ClassificacaoSession = categoriaClassificacaoRepository.FindById(id);
            }
            return ClassificacaoSession;
        }

        public static Classificacao NewClassificacao()
        {
            return new Classificacao()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Cla_descricao = Faker.Company.Name(),
            };
        }
    }
}
