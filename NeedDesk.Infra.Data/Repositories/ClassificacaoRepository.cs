using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;

namespace NeedDesk.Infra.Data.Repositories
{
    public class ClassificacaoRepository : RepositoryBase<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Status(Classificacao classificacao)
        {
            string sql = "update Classificacao set Cla_inativo = @Cla_inativo where Cla_id = @Cla_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    classificacao.Cla_id,
                    classificacao.Cla_inativo
                });

            return rowseffected > 0;
        }
    }
}
