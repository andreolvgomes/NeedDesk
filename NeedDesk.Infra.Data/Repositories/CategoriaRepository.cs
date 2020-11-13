using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public bool Inativar(Guid cat_id)
        {
            int rowseffected = _connectionFactory.Connect()
                .Execute("update Categorias set Cat_inativo = 1 where cat_id = @cat_id",
                new { cat_id });

            return rowseffected > 0;
        }
    }
}
