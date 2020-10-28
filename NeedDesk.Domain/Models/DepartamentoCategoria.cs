using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class DepartamentoCategoria : EntityMaster
    {
        public Int64 DepartamentoId { get; set; }
        public Int64 CategoriaId { get; set; }
        public bool Dep_vinculado { get; set; }
    }
}