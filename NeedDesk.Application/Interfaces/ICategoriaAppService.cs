using NeedDesk.Application.DTO.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface ICategoriaAppService
    {
        IEnumerable<CategoriaResult> All();
        Guid Create(CategoriaCreate categoriaCreate);
        void Update(CategoriaUpdate categoriaUpdate);
        void Remove(Guid cat_id);
        CategoriaResult Get(Guid cat_id);
        bool Inativar(Guid cat_id);
    }
}