﻿using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        public bool Status(Colaborador colaborador);
    }
}
