using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;

namespace NeedDesk.Infra.Data.Repositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Status(Status status)
        {
            string sql = "update Status set Sta_inativo = @Sta_inativo where Sta_id = @Sta_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    status.Sta_id,
                    status.Sta_inativo
                });

            return rowseffected > 0;
        }
    }
}
