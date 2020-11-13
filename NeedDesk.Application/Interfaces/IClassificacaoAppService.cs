using NeedDesk.Application.DTO.Classificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface IClassificacaoAppService
    {
        IEnumerable<ClassificacaoResult> All();
        Guid Create(ClassificacaoCreate classificacaoCreate);
        void Update(ClassificacaoUpdate classificacaoUpdate);
        void Remove(Guid cat_id);
        ClassificacaoResult Get(Guid cat_id);
        bool Status(ClassificacaoStatus classificacaoStatus);
    }
}