using NeedDesk.Application.DTO.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Application.Interfaces
{
    public interface ICategoriaAppService
    {
        IEnumerable<CategoriaResult> All();
        Int64 Create(CategoriaCreate categoriaCreate);
        void Update(CategoriaUpdate categoriaUpdate);
        void Remove(Int64 cat_id);
        CategoriaResult Get(Int64 cat_id);
    }
}