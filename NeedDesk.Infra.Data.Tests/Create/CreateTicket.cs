using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Tests
{
    public class CreateTicket
    {
        private static Ticket TicketSession;

        public static Ticket Ticket()
        {
            if (TicketSession == null)
            {
                ITicketRepository ticketRepository = new TicketRepository();
                var id = ticketRepository.Insert(NewTicket());
                TicketSession = ticketRepository.FindById(id);
            }
            return TicketSession;
        }

        public static Ticket NewTicket()
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
