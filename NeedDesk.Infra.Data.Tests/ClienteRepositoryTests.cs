using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class ClienteRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                IClienteRepository clienteRepository = new ClienteRepository();

                // test insert
                var id = (Int64)clienteRepository.Insert(CreateCliente.NewCliente());
                Assert.True(id > 0);

                // test get by id
                Cliente cliente = clienteRepository.FindById(id);
                Assert.True(cliente != null);

                // test update
                cliente.CreateAt = DateTime.Now;
                var rowscuccess = clienteRepository.Update(cliente);
                Assert.True(rowscuccess > 0);

                // test delete
                clienteRepository.Delete(cliente);

                for (int i = 1; i <= 5; i++)
                    clienteRepository.Insert(CreateCliente.NewCliente());

                var list = clienteRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
