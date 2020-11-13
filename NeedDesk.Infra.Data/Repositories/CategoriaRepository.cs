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

        public bool Status(Categoria categoria)
        {
            string sql = "update Categorias set Cat_inativo = @Cat_inativo where cat_id = @cat_id";
            int rowseffected = _connectionFactory.Connect().Execute(sql,
                new
                {
                    categoria.Cat_id,
                    categoria.Cat_inativo
                });

            return rowseffected > 0;
        }
    }
}