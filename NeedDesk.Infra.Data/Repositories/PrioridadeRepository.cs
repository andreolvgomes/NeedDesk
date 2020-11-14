using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;

namespace NeedDesk.Infra.Data.Repositories
{
    public class PrioridadeRepository : RepositoryBase<Prioridade>, IPrioridadeRepository
    {
        public PrioridadeRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Status(Prioridade prioridade)
        {
            string sql = "update Prioridades set Pri_inativo = @Pri_inativo where Pri_id = @Pri_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    prioridade.Pri_id,
                    prioridade.Pri_inativo
                });

            return rowseffected > 0;
        }
    }
}