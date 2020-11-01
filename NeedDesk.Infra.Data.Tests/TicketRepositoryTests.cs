using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class TicketRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                ITicketRepository ticketRepository = new TicketRepository();

                // test insert
                var id = (Int64)ticketRepository.Insert(NewTicket());
                Assert.True(id > 0);

                // test get by id
                Ticket ticket = ticketRepository.FindById(id);
                Assert.True(ticket != null);

                // test update
                ticket.CreateAt = DateTime.Now;
                var rowscuccess = ticketRepository.Update(ticket);
                Assert.True(rowscuccess > 0);

                // test delete
                ticketRepository.Delete(ticket);

                for (int i = 1; i <= 5; i++)
                    ticketRepository.Insert(NewTicket());

                var list = ticketRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Ticket NewTicket()
        {
            return new Ticket()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Dep_id = CreateDepartamento.Departamento().Dep_id,
                Cli_id = CreateCliente.Cliente().Cli_id,
                Col_id_soli = CreateColaborador.Colaborador().Col_id,
                Col_id_pend = CreateColaborador.Colaborador(true).Col_id,
                Pri_id = CreatePrioridade.Prioridade().Pri_id,
                Cat_id = CreateCategoria.Categoria().Cat_id,
                Cla_id = CreateClassificacao.Classificacao().Cla_id,
                Sta_id = CreateStatus.Status().Sta_id,
                Tick_assunto = Faker.Company.Name() + " " + Faker.Company.Suffix(),
                Tick_tipo = 0
            };
        }
    }
}
