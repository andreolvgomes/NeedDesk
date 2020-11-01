using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateColaborador
    {
        private static Colaborador ColaboradorSession;

        public static Colaborador Colaborador()
        {
            if (ColaboradorSession == null)
            {
                IColaboradorRepository colaboradorRepository = new ColaboradorRepository();
                var id = colaboradorRepository.Insert(NewColaborador());
                ColaboradorSession = colaboradorRepository.FindById(id);
            }
            return ColaboradorSession;
        }

        public static Colaborador NewColaborador()
        {
            return new Colaborador()
            {
                Tenant_id = CreateUser.User().Tenant_id,
                Use_id = CreateUser.User().Use_id,
                Col_nome = Faker.Name.First(),
                Col_sobrenome = Faker.Name.Last(),
            };
        }
    }
}
