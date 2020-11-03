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
    }
}
