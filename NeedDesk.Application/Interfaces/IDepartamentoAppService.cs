using NeedDesk.Application.DTO.Departamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IDepartamentoAppService
    {
        IEnumerable<DepartamentoResult> All();
        Guid Create(DepartamentoCreate departamentoCreate);
        void Update(DepartamentoUpdate departamentoUpdate);
        void Remove(Guid cat_id);
        DepartamentoResult Get(Guid cat_id);
        bool Status(DepartamentoStatus departamentoStatus);
    }
}