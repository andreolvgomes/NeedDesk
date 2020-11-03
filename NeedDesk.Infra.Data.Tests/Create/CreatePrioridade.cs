using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreatePrioridade
    {
        private static Prioridade PrioridadeSession;

        public static Prioridade Prioridade()
        {
            if (PrioridadeSession == null)
            {
                IPrioridadeRepository prioridadeRepository = new PrioridadeRepository(Test.Connect);
                var id = prioridadeRepository.Insert(NewPrioridade());
                PrioridadeSession = prioridadeRepository.FindById(id);
            }
            return PrioridadeSession;
        }

        public static Prioridade NewPrioridade()
        {
            return new Prioridade()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Pri_descricao = Faker.Company.Name(),
            };
        }
    }
}
