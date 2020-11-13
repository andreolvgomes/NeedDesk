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
                ITicketRepository ticketRepository = new TicketRepository(Test.Connect);

                // test insert
                var id = (Guid)ticketRepository.Insert(CreateTicket.NewTicket());
                Assert.True(!id.IsEmpty());

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
                    ticketRepository.Insert(CreateTicket.NewTicket());

                var list = ticketRepository.All("tenant_id <> ''");
                Assert.True(list.Count() > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
    }
}
