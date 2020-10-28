using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Departamento : EntityMaster
    {
        public string Dep_descricao { get; set; }
        public bool Dep_inativo { get; set; }
    }
}