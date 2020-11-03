using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NeedDesk.Infra.Data.Tests
{
    public class TicketAndamentoRepositoryTests
    {
        [Fact]
        public void CrudTest()
        {
            try
            {
                ITicketAndamentoRepository ticketAndamentoRepository = new TicketAndamentoRepository(Test.Connect);

                // test insert
                var id = (Int64)ticketAndamentoRepository.Insert(NewTicketAndamento());
                Assert.True(id > 0);

                // test get by id
                TicketAndamento ticketAndamento = ticketAndamentoRepository.FindById(id);
                Assert.True(ticketAndamento != null);

                // test update
                ticketAndamento.CreateAt = DateTime.Now;
                var rowscuccess = ticketAndamentoRepository.Update(ticketAndamento);
                Assert.True(rowscuccess > 0);

                // test delete
                ticketAndamentoRepository.Delete(ticketAndamento);

                for (int i = 1; i <= 5; i++)
                    ticketAndamentoRepository.Insert(NewTicketAndamento());

                var list = ticketAndamentoRepository.All("tenant_id > 0");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private TicketAndamento NewTicketAndamento()
        {
            return new TicketAndamento()
            {
                Tenant_id = CreateTenant.Tenant_id(),
                Tic_id = CreateTicket.Ticket().Tic_id,
                 And_texto = Faker.Lorem.Paragraph()
            };
        }
    }
}
