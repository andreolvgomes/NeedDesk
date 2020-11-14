using NeedDesk.Application.DTO.Colaborador;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IColaboradorAppService
    {
        IEnumerable<ColaboradorResult> All();
        Guid Create(ColaboradorCreate colaboradorCreate);
        void Update(ColaboradorUpdate colaboradorUpdate);
        void Remove(Guid cat_id);
        ColaboradorResult Get(Guid cat_id);
        bool Status(ColaboradorStatus colaboradorStatus);
    }
}