using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Status(Cliente cliente)
        {
            string sql = "update Clientes set Cli_inativo = @Cli_inativo where Cli_id = @Cli_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    cliente.Cli_id,
                    cliente.Cli_inativo
                });

            return rowseffected > 0;
        }
    }
}
