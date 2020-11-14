using NeedDesk.Application.DTO.Prioridade;
using System;
using System.Collections.Generic;

namespace NeedDesk.Application.Interfaces
{
    public interface IPrioridadeAppService
    {
        IEnumerable<PrioridadeResult> All();
        Guid Create(PrioridadeCreate prioridadeCreate);
        void Update(PrioridadeUpdate prioridadeUpdate);
        void Remove(Guid cat_id);
        PrioridadeResult Get(Guid cat_id);
        bool Status(PrioridadeStatus prioridadeStatus);
    }
}