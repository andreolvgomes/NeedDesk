﻿using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class ClassificacaoRepository : RepositoryBase<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }
    }
}
