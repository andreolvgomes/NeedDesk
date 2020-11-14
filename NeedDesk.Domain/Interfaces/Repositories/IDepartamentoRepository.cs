using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Interfaces.Repositories
{
    public interface IDepartamentoRepository : IRepositoryBase<Departamento>
    {
        public bool Status(Departamento departamento);
    }
}
