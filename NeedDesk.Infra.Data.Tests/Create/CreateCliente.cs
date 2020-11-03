using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateCliente
    {
        private static Cliente ClienteSession;

        public static Cliente Cliente()
        {
            if (ClienteSession == null)
            {
                IClienteRepository clienteRepository = new ClienteRepository(Test.Connect);
                var id = clienteRepository.Insert(NewCliente());
                ClienteSession = clienteRepository.FindById(id);
            }
            return ClienteSession;
        }

        public static Cliente NewCliente()
        {
            return new Cliente()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Cli_nome = Faker.Name.FullName()
            };
        }
    }
}
