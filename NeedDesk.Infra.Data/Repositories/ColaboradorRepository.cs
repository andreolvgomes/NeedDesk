using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class ColaboradorRepository : RepositoryBase<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Status(Colaborador colaborador)
        {
            string sql = "update Colaboradores set Col_inativo = @Col_inativo where Col_id = @Col_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    colaborador.Col_id,
                    colaborador.Col_inativo
                });

            return rowseffected > 0;
        }
    }
}