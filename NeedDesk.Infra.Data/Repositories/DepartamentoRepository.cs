using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class DepartamentoRepository : RepositoryBase<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Status(Departamento departamento)
        {
            string sql = "update Departamentos set Dep_inativo = @Dep_inativo where Dep_id = @Dep_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    departamento.Dep_id,
                    departamento.Dep_inativo
                });

            return rowseffected > 0;
        }
    }
}
