using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        bool Status(Categoria categoria);
    }
}
